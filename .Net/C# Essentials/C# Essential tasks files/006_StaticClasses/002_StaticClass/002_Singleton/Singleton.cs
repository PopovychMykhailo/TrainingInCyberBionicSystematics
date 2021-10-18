using System;

namespace Static
{
    // "Singleton"
    class Singleton
    {
        private static Singleton instance = null;

        // Конструктор - "protected" 
        protected Singleton() 
        {
        }

        // Фабричный метод.
        public static Singleton GetInstance()
        {
            // Если: объект еще не создан    (1)         
            if (instance == null)
            {
                // То: создаем новый экземпляр  (2)
                instance = new Singleton();
            }
            // Иначе: возвращаем ссылку на существующий объект  (3)
            return instance;
        }
    }
}
