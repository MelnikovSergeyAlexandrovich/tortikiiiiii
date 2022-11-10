using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5_cakes
{

    //Должен быть свой тип данных - подпункт меню(условно говоря, я нажимаю enter и у меня выводятся все подпункты меню.
    internal class SubItem
    {

        //Подпункт хранит в себе описание и цену подпункта)
        public string Text { get; set; }
        public int Price { get; set; }

        //Внутри подпункта меню нужно создать конструктор, чтобы из кода можно было проще создавать объект этого меню
        public SubItem(string text, int price)
        {
            this.Text = text;
            this.Price = price;
        }

    }
}
