using System;
using System.Collections;

namespace Homework_task2
{
    /* Technical task
    
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте класс CarCollection<T>. Реализуйте в простейшем приближении возможность
        использования его экземпляра для создания парка машин. Минимально требуемый интерфейс
        взаимодействия с экземпляром, должен включать метод:
            1. Добавления машин с названием машины и года ее выпуска
            2. Индексатор для получения значения элемента по указанному индексу
            3. Свойство только для чтения для получения общего количества элементов.
            4. Метод удаления всех машин автопарка.
    */

    public class CarCollection<TCar> where TCar : struct
    {
        ArrayList arrayCars;


        public CarCollection()
        {
            arrayCars = new ArrayList(0);
        }

        public CarCollection(int length)
        {
            arrayCars = new ArrayList(length);
        }

        public void Add(TCar newCar)
        {
            arrayCars.Add(newCar);
        }

        public TCar this[int index]
        {
            set
            {
                if (index >= 0 && index < arrayCars.Count)
                    arrayCars[index] = value;
                else
                    throw new Exception("Attention: the index out of range the CarCollection!");
            }

            get
            {
                if (index >= 0 && index < arrayCars.Count)
                    return (TCar)arrayCars[index];
                else
                    throw new Exception("Attention: the index out of range the CarCollection!");
            }
        }

        public int Length
        {
            get => arrayCars.Count;
        }

        public void ClearCollection()
        {
            arrayCars = new ArrayList();
        }
    }

    public struct Car
    {
        public string Model { set; get; }
        public int DateOfManufacture { set; get; }

        public Car(string model, int dateOfManufacture)
        {
            Model = model;
            DateOfManufacture = dateOfManufacture;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarCollection<Car> carCollection = new(3);

            carCollection.Add(new Car("Tesla", 2022));
            carCollection.Add(new Car("Jauar", 2020));
            carCollection.Add(new Car("Audi", 2019));

            //carCollection.ClearCollection();  // To clear, uncomment this string

            for (int i = 0; i < carCollection.Length; i++)
                Console.WriteLine($"carCollection[{i}]: {carCollection[i].Model}, {carCollection[i].DateOfManufacture}");

        }
    }
}
