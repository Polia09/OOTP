using laba4;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

bool menuCheck = true;
Films temp;
int i;
int j;
Catalog catalog = new Catalog();

while (menuCheck)
{
    Console.Clear();
    Console.WriteLine("---Меню---\n" +
        "1.Добавить информацию о каталоге\n" +
        "2.Изменить информацию о каталоге\n" +
        "3.Очистить информацию о каталоге\n" +
        "4.Вывести информацию о каталоге\n" +
        //"5.Добавить фильм в каталог\n" +
        "6.Просмотреть список фильмов в каталоге\n" +
        "7.Изменить информацию о фильме в каталоге по индексу\n" +
        "8.Удалить фильм из каталога по индексу\n" +
        "9.Просмотреть информацию о фильме из каталога по индексу\n" +
        "-------------------------------\n" +
        //"10.Добавить копий фильма в каталог по индексу\n" +
        //"11.Добавить фильм в каталог используя конструктор с параметрами\n" +
        //"12.Перемещение фильма из каталога по индексу в новый объект\n" +
        "-------------------------------\n" +
        "13.Добавить избранный фильм в каталог\n" +
        "14.Добавить заблокированный фильм в каталог\n" +
        "-------------------------------\n");
    while (!int.TryParse(Console.ReadLine(), out i))
        Console.WriteLine("Необходимо ввести число:");
    switch (i)
    {
        case 1:
            Console.Clear();
            catalog.AddCatalogInfo();
            break;
        case 2:
            Console.Clear();
            catalog.ChangeCatalogInfo();
            break;
        case 3:
            Console.Clear();
            catalog.RemoveCatalogInfo();
            break;
        case 4:
            Console.Clear();
            catalog.PrintCatalogInfo();
            break;
        //case 5:
        //    Console.Clear();
        //    Console.WriteLine("Добавлять можно только объекты классов наследников");
        //    break;
        case 6:
            Console.Clear();
            if (catalog.IsListEmpty()) { Console.WriteLine("Список пуст!"); break; }
            catalog.PrintFilmList();
            break;
        case 7:
            Console.Clear();
            if (catalog.IsListEmpty()) { Console.WriteLine("Список пуст!"); break; }
            Console.WriteLine("Введите индекс фильма в каталоге:");
            while (!int.TryParse(Console.ReadLine(), out j) || j >= catalog.FilmListCount() || j < 0)
            {
                Console.WriteLine("Неверный ввод!");
            }
            temp = catalog.GetOutOfList(j);
            temp.ChangeFilmInfo();
            catalog.AddFilmToCatalogList(temp);
            break;
        case 8:
            Console.Clear();
            if (catalog.IsListEmpty()) { Console.WriteLine("Список пуст!"); break; }
            Console.WriteLine("Введите индекс фильма в каталоге:");
            while (!int.TryParse(Console.ReadLine(), out j) || j >= catalog.FilmListCount() || j < 0)
            {
                Console.WriteLine("Неверный ввод!");
            }
            if (catalog.GetOutOfList(j) != null)
                Console.WriteLine("Фильм успешно удален");
            break;
        case 9:
            Console.Clear();
            if (catalog.IsListEmpty()) { Console.WriteLine("Список пуст!"); break; }
            Console.WriteLine("Введите индекс фильма в каталоге:");
            while (!int.TryParse(Console.ReadLine(), out j) || j >= catalog.FilmListCount() || j < 0)
            {
                Console.WriteLine("Неверный ввод!");
            }
            temp = catalog.GetOutOfList(j);
            temp.PrintFilmInfo();
            catalog.AddFilmToCatalogList(temp);
            break;
        //case 10:
        //    Console.Clear();
        //    if (catalog.IsListEmpty()) { Console.WriteLine("Список пуст!"); break; }
        //    Console.WriteLine("Введите индекс фильма в каталоге:");
        //    while (!int.TryParse(Console.ReadLine(), out j) || j >= catalog.FilmListCount() || j < 0)
        //    {
        //        Console.WriteLine("Неверный ввод!");
        //    }
        //    temp = catalog.GetOutOfList(j);
        //    Console.WriteLine("Введите необходимое количество копий:");
        //    while (!int.TryParse(Console.ReadLine(), out j))
        //    {
        //        Console.WriteLine("Неверный ввод!");
        //    }
        //    catalog.AddFilmsCoppiesToCatalogList(temp, j);
        //    break;
        //case 11:
        //    Console.Clear();
        //    catalog.AddFilmToCatalogListWithParametrs();
        //    break;
        //case 12:
        //    Console.Clear();
        //    if (catalog.IsListEmpty()) { Console.WriteLine("Список пуст!"); break; }
        //    Console.WriteLine("Введите индекс фильма в каталоге:");
        //    while (!int.TryParse(Console.ReadLine(), out j) || j >= catalog.FilmListCount() || j < 0)
        //    {
        //        Console.WriteLine("Неверный ввод!");
        //    }
        //    temp = catalog.GetOutOfList(j);
        //    catalog.AddFilmToCatalogListWithMove(ref temp);
        //    break;
        case 13:
            Console.Clear();
            Favourite f_film = new Favourite();
            f_film.AddFilmInfo();
            catalog.AddFilmToCatalogList(f_film);
            break;
        case 14:
            Console.Clear();
            Blocked b_film = new Blocked();
            b_film.AddFilmInfo();
            catalog.AddFilmToCatalogList(b_film);
            break;
        default:
            Console.Clear();
            Console.WriteLine("Номера нет в списке.");
            break;
    }
    CheckForCont();
}
void CheckForCont()
{
    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить.\n");
    Console.ReadKey();
}