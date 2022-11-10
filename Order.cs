using lr5_cakes;
using System.Xml.Linq;

//Необходимо создать отдельный класс для заказа.
internal class Order
{
    private Dictionary<string, SubItem> choices = new Dictionary<string, SubItem>();
    private readonly Dictionary<string, MenuItem> menuItems = new Dictionary<string, MenuItem>
    {                        
        //        Выбор торта должен быть реализован из нескольких пунктов:
        //        форма, размер, вкус, количество, глазурь и декор.
        {"Форма торта",
        new MenuItem("Форма торта", new Dictionary<string, SubItem>
        {
            {"Круг" , new SubItem("Круг", 400) },
            {"Квадрат",new SubItem("Квадрат", 500)      },
            {"Прямоугольник",new SubItem("Прямоугольник", 500)  },
            {"Сердечко",new SubItem("Сердечко", 800) },
            {"Ваша собственная форма",new SubItem("Ваша собственная форма", 1000) },
        }) } ,

         {"Размер торта",
        new MenuItem("Размер торта", new Dictionary<string, SubItem>
        {
            {"Маленький (8 порций)",new SubItem("Маленький (8 порций)", 1000)  },
             { "Средний (12 порций)",new SubItem("Средний (12 порций)", 1300)  },
             { "Большой (24 порций)",new SubItem("Большой (24 порций)", 1000)  },
}
        }) },

         {"Количество коржей",
        new MenuItem("Количество коржей", new Dictionary<string, SubItem>
        {
            {"1 Корж ", new SubItem("1 Корж," 200)},
            { "2 Корж ", new SubItem("2 Коржa," 400)},
            { "3 Корж ", new SubItem("3 Коржa," 600)},
            { "4 Корж ", new SubItem("4 Коржa," 800)} , 
        }) },

 {
    "Глазурь",
        new MenuItem("Глазурь", new Dictionary<string, SubItem>
        {
            {"Шоколад", new SubItem("Шоколад", 100)},
            {"Крем", new SubItem("Крем", 100)},
            {"Драже", new SubItem("Драже", 150)},
            {"Ягоды", new SubItem("Ягоды", 200)},
            {"Фрукты", new SubItem("Фрукты", 200)},
        }) },
    "Декор",
        new MenuItem("Декор", new Dictionary<string, SubItem>
        {
            {"Шоколадная", new SubItem("Шоколадная"), 200 },
            {"Фруктовая", new SubItem("Фруктовая"), 200 },
            {"Ягодная", new SubItem("Ягодная"), 200 },
            {"Кремовая", new SubItem("Кремовая"), 200 }
        }) },


        {
    "вкус коржей",
        new MenuItem("вкус коржей", new Dictionary<string, SubItem>
        {
            {"Ванильный", new SubItem("Ванильный", 200)  } ,
            {"Шоколадный", new SubItem("Шоколадный", 200) } ,
            {"Карамельный", new SubItem("Карамельный", 200)} ,
            {"Ягодный", new SubItem("Ягодный", 200)    } ,
            {"Кокосовый", new SubItem("Кокосовый", 300) } ,
             {"Фруктовый", new SubItem("Фруктовый", 340) } ,
        }) },
        {"конец заказа",
        new MenuItem("конец заказа", new Dictionary<string, SubItem>()) },
    };

    



    public void GetOrder()
    {
        var menu = new Menu(menuItems.Select(m => m.Key).ToArray());
        while (true)
        {
            var (item, exit) = menu.MainLoop(this);
            if (exit)
            {
                Save();
                return;
            }
            if (item == "конец заказа")
            {
                Save();
                return;
            }
            ChooseMenuItem(menuItems[item]);

        }
    }

    private void Save()
    {
        using (var writer = new StreamWriter("orders.txt", new FileStreamOptions { Mode = FileMode.Append, Access = FileAccess.Write }))
        {
            writer.WriteLine("заказ от " + DateTime.Now);
            writer.Write("\t\t");
            writer.WriteLine(String.Join("; ", choices.Values.Select(x => x.Text + " - " + x.Price)));
            writer.WriteLine("price: " + GetPrice());
        }
    }

    //Внутри класса должен быть следующий функционал:
    //выбор пункта основного меню,
    private void ChooseMenuItem(MenuItem menuItem)
    {
        var menu = new Menu(menuItem.SubItems.Select(kv => kv.Key + " " + kv.Value.Price).ToArray());
        while (true)
        {
            var (item, exit) = menu.MainLoop(null);
            if (exit)
            {
                return;
            }
            var key = item.Split()[0];
            ChooseMenuSubItem(menuItem.Text, menuItem.SubItems[key]);
            return;
        }
    }

    //выбор пункта дополнительного меню(ОДИН МЕТОД, НЕ НЕСКОЛЬКО ДЛЯ КАЖДОГО!),
    private void ChooseMenuSubItem(string item, SubItem subItem)
    {
        choices[item] = subItem;
    }

    internal string GetDescription()
    {
        return string.Join("; ", choices.Select(c => c.Value.Text + " " + c.Value.Price));
       
    }

    internal int GetPrice()
    {
        return choices.Sum(c => c.Value.Price);
    }
    //сохранение в файл.Остальные методы по желанию.
    //Методы внутри класса заказа должны быть как приватными, так и публичными
    //За каждый невыполненный подпункт - минус 0.5 балла.Ниже 2 оценки быть не может
}