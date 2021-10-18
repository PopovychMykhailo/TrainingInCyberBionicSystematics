using System;

namespace Homework_task2
{
    /* Technical task
     
        Создайте класс Block с 4-мя полями сторон, переопределите в нем методы:
        Equals – способный сравнивать блоки между собой,
        ToString – возвращающий информацию о полях блока
    */

    class Block
    {
        public int SideA { set; get; }
        public int SideB { set; get; }
        public int SideC { set; get; }
        public int SideD { set; get; }


        public Block() { }
        public Block(int sideA, int sideB, int sideC, int sideD)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            SideD = sideD;
        }


        public override bool Equals(object obj)
        {
            bool result = false;

            // Check for null and compare types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                result = false;
            }
            else
            {
                Block block = (Block)obj;

                // Check properties
                if (block.SideA == SideA &&
                    block.SideB == SideB &&
                    block.SideC == SideC &&
                    block.SideD == SideD)
                {
                    result = true;
                }
            }

            return result;
        }
        public override string ToString()
        {
            return $"Type \"{this.GetType()}\". SideA {SideA}, SideB {SideB}, SideC {SideC}, SideD {SideD}.";
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main()
        {
            Block block1 = new(1, 2, 3, 4);
            Block block2 = new(4, 3, 2, 1);

            Console.WriteLine($"Blocks is equel:   {block1.Equals(block2)}");
            Console.WriteLine($"block1.ToString(): {block1}");
        }
    }
}
