using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_task4
{
    class Article
    {
        private int _price;

        public string NameProduct { set; get; }
        public string NameStore { set; get; }
        public int Price
        {
            set
            {
                if (value >= 0)
                    _price = value;
                else
                    throw new Exception("Error: price cannot be below 0!");
            }

            get
            {
                return _price;
            }
        }



        public Article(string nameProduct, string nameStore, int price)
        {
            this.NameProduct = nameProduct;
            this.NameStore = nameStore;
            this.Price = price;
        }

        public Article()
        {

        }
    }
}
