﻿using System;
using System.Text;

public class Program
{
    static int sum(int a, int b)
    {
        return a + b;
    }
    static void Endik()
    {
        var r = sum(1, 2);
        Console.WriteLine(r);
        while (true)
        {
     
            
            Console.WriteLine("Спасибо за заказ!!! Если хотите сделать ещё один, то нажмите ESC");
            var key = Console.ReadKey();
            if (key.Key != ConsoleKey.Escape)
            {
                break;
            }
        }
    }




    public static void Main()
    {
        Endik();

    }
}

        //order.ChooseMenuItem("форма");
        //order.ChooseMenuSubItem(new SubItem("круг", 500));
        //Необходимо реализовать программу по заказу тортов для условной кондитерской в консоли

        //var menu = new MainMenu();
        //menu.MainLoop();

        //При нажатии Enter это меню должно переходить в дополнительное меню с выбором определенного вида пункта.Внутри должно быть не менее трех пунктов.
        //Должна быть возможность выхода их этого меню по нажатию клавиши Escape
        //Должен быть вывод суммарной цены и суммарного заказа
        //По окончанию заказа итоговый заказ и его стоимость должен быть сохранен в файл в формате, представленный в текстовом файле "История заказов"(на видео ошибка, там нет сохранения цены).Вместо значений, указанных в<>, должны быть значения из кода.Все заказы, сделанные в приложении, должны сохраняться в этом файле.Расположение на ваш выбор
        //Должна быть возможность после оформления заказа сделать еще один заказ
        //Из структуры кода, необходимо реализовать следующее:


    

