using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class Catalog
    {
        private string name;
        private int year;
        private List<Films> films;
        public Catalog()
        {
            Console.WriteLine("Вызван конструктор осн. класса по умолчанию");
            this.name = "undefined";
            this.year = 0;
            this.films = new List<Films>();
        }
        public Catalog(string name, int year, List<Films> films = null)
        {
            Console.WriteLine("Вызван конструктор осн. класса с параметрами");
            this.name = name;
            this.year = year;
            this.films = films;
        }
        public Catalog(Catalog catalog)
        {
            Console.WriteLine("Вызван конструктор осн. класса копирования");
            this.name = catalog.name;
            this.year = catalog.year;
            this.films = catalog.films;
        }
        public Catalog(ref Catalog catalog)
        {
            Console.WriteLine("Вызван конструктор осн. класса перемещения");
            this.name = catalog.name;
            catalog.name = null;
            this.year = catalog.year;
            catalog.year = 0;
            this.films = catalog.films;
            catalog.films.Clear();
        }
        ~Catalog()
        {
            Console.WriteLine("Вызван деструктор осн. класса");
            this.name = null;
            this.year = 0;
            this.films.Clear();
        }
        //public void AddFilmsCoppiesToCatalogList(Films films, int count)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        Films film = new Films(films);
        //        this.AddFilmToCatalogList(film);
        //    }
        //}
        //public void AddFilmToCatalogListWithParametrs()
        //{
        //    Console.WriteLine("Введите название фильма: ");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Введите жанр фильма: ");
        //    string genre = Console.ReadLine();
        //    Console.WriteLine("Введите описание фильма: ");
        //    string description = Console.ReadLine();
        //    Films film = new Films(name, genre, description);
        //    this.films.Add(film);
        //}
        //public void AddFilmToCatalogListWithMove(ref Films film)
        //{
        //    Films film1 = new Films(film);
        //    this.films.Add(film1);
        //}
        public int FilmListCount()
        {
            return films.Count();
        }
        public bool IsListEmpty()
        {
            if (films.Count == 0)
                return true;
            else return false;
        }
        public void PrintCatalogInfo()
        {
            Console.WriteLine($"Название: {this.name}, год: {year}\nФильмы:");
            foreach (var film in films)
            {
                film.PrintFilmInfo();
            }

        }
        public void PrintFilmList()
        {
            for (int i = 0; i < films.Count; i++)
            {
                Console.WriteLine($"Фильм с индексом {i}");
                films[i].PrintFilmInfo();
            }
        }
        public void AddCatalogInfo()
        {
            Console.WriteLine("Введите название каталога: ");
            this.name = Console.ReadLine();
            Console.WriteLine("Введите год каталога: ");
            int intTemp;
            while (!int.TryParse(Console.ReadLine(), out intTemp))
                Console.WriteLine("Неоходимо ввести число!");
            this.year = intTemp;
        }
        public void ChangeCatalogInfo()
        {
            bool check = true;
            while (check)
            {
                int i;
                Console.WriteLine("Текущая информация о каталоге: ");
                this.PrintCatalogInfo();
                Console.WriteLine("Выберете поле которое хотите поменять:\n1.Название\n2.Год");
                while (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.WriteLine("Необходимо ввести число: ");
                }
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Введите новое название каталога: ");
                        this.name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите год каталога: ");
                        int intTemp;
                        while (!int.TryParse(Console.ReadLine(), out intTemp))
                            Console.WriteLine("Неоходимо ввести число!");
                        this.year = intTemp;
                        break;
                    default:
                        Console.WriteLine("Такого поля нет.");
                        break;
                }
                Console.WriteLine("Введите Y или Н чтобы продолжить изменение: ");
                char c = Console.ReadKey().KeyChar;
                if (c != 'Y' && c != 'y' && c != 'Н' && c != 'н')
                    check = false;
            }
        }
        public void RemoveCatalogInfo()
        {
            this.name = "undefined";
            this.year = 0;
            this.films.Clear();
            Console.WriteLine("Информация о каталоге удалена.");
        }
        public void AddFilmToCatalogList(Films film)
        {
            this.films.Add(film);
        }
        public Films GetOutOfList(int index)
        {
            if (index < 0 || index >= this.films.Count || this.IsListEmpty())
                return null;
            else
            {
                Films temp = this.films[index];
                this.films.RemoveAt(index);
                return temp;
            }
        }
    }
}
