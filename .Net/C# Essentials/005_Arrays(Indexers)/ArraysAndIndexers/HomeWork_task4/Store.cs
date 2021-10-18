using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_task4
{
    class Store
    {
        Article[] listArticle;
        public int Length
        {
            get
            {
                return listArticle.Length;
            }
        }

        public Store()
        {
            listArticle = new Article[5];
            listArticle[0] = new Article("Sumsung Note 20 Ultra", "Velyka Vasylkivska 72", 35000);
            listArticle[1] = new Article("Xiaomi Mi 11 Ultra", "Velyka Vasylkivska 72", 35000);
            listArticle[2] = new Article("OnePlus 9 Pro", "47 Peremohy Avenue", 30000);
            listArticle[3] = new Article("Sumsung Note 10", "Velyka Vasylkivska 72", 18000);
            listArticle[4] = new Article("Apple iPhone 13", "47 Peremohy Avenue", 40000);
        }

        public void ShowAll()
        {
            for (int i = 0; i < listArticle.Length; i++)
            {
                ShowProduct(listArticle[i]);
            }
        }

        public void ShowProduct(Article article)
        {
            Console.WriteLine($"Name:  {article.NameProduct}");
            Console.WriteLine($"Store: {article.NameStore}");
            Console.WriteLine($"Price: {article.Price}");
            Console.WriteLine();
        }

        public Article this[int index]
        {
            set { listArticle[index] = value; }
            get { return listArticle[index]; }
        }

        public Article this[string index]
        {
            get
            {
                for (int i = 0; i < listArticle.Length; i++)
                {
                    if (listArticle[i].NameProduct == index)
                    {
                        return listArticle[i];
                    }
                }

                throw new Exception("Autenthion: the store doesn't have this product!");
            }
        }
    }
}
