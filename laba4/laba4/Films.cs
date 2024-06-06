using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    abstract class Films
    {
        private string name;
        private string description;
        private string genre;
        public Films()
        {
            Console.WriteLine("Вызван конструктор доп. класса по умолчанию");
            this.name = "undefined";
            this.description = "undefined";
            this.genre = "undefined";
        }
        public Films(string name, string description, string genre)
        {
            Console.WriteLine("Вызван конструктор доп. класса с параметрами");
            this.name = name;
            this.description = description;
            this.genre = genre;
        }
        public Films(Films films)
        {
            Console.WriteLine("Вызван конструктор доп. класса копирования");
            this.name = films.name;
            this.description = films.description;
            this.genre = films.genre;
        }
        public Films(ref Films films)
        {
            Console.WriteLine("Вызван конструктор доп. класса перемещения");
            this.name = films.name;
            films.name = null;
            this.description = films.description;
            films.description = null;
            this.genre = films.genre;
            films.genre = null;
        }
        ~Films()
        {
            Console.WriteLine("Вызван деструктор доп. класса");
            this.name = "undefined";
            this.description = "undefined";
            this.genre = "undefined";
        }
        public virtual void PrintFilmInfo() { }

        public virtual void AddFilmInfo() { }
        public virtual void ChangeFilmInfo() { }
        public virtual void RemoveFilmInfo() { }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetDescription()
        {
            return this.description;
        }
        public void SetGenre(string genre)
        {
            this.genre = genre;
        }
        public string GetGenre()
        {
            return this.genre;
        }
    }

    class Favourite : Films
    {
        public DateTime time_of_add;
        public Favourite()
        {
            Console.WriteLine("Вызван конструктор наследника (Избранное) доп. класса по умолчанию");
            this.time_of_add = new DateTime();
        }
        public Favourite(string name, string description, string genre, DateTime time_of_add)
        {
            Console.WriteLine("Вызван конструктор наследника (Избранное) доп. класса с параметрами");
            this.SetName(name);
            this.SetDescription(description);
            this.SetGenre(genre);
            this.time_of_add = time_of_add;
        }
        public Favourite(Favourite f)
        {
            Console.WriteLine("Вызван конструктор наследника (Избранное) доп. класса копирования");
            this.time_of_add = f.time_of_add;
            this.SetName(f.GetName());
            this.SetGenre(f.GetGenre());
            this.SetDescription(f.GetDescription());
        }
        ~Favourite()
        {
            Console.WriteLine("Вызван деструктор наследника (Избранное) доп. класса");
            this.SetName("undefined");
            this.SetDescription("undefined");
            this.SetGenre("undefined");
            this.time_of_add = DateTime.ParseExact("1.1.0001.0.0.0", "d,M,yyy,H,m,s", null, System.Globalization.DateTimeStyles.None);
        }
        public override void PrintFilmInfo() { Console.WriteLine($"Название избранного фильма: {this.GetName()}, жанр: {this.GetGenre()}\nОписание: {this.GetDescription()}\nДата добавления фильма в избранное: {this.time_of_add}"); }
        public override void AddFilmInfo()
        {
            Console.WriteLine("Введите название фильма: ");
            this.SetName(Console.ReadLine());
            Console.WriteLine("Введите жанр фильма: ");
            this.SetGenre(Console.ReadLine());
            Console.WriteLine("Введите описание фильма: ");
            this.SetDescription(Console.ReadLine());
            Console.WriteLine("Введите время добавления фильма в избранное(формат'день.месяц.год.час.минута.секунда'): ");
            string input;
            do
                input = Console.ReadLine();
            while (!DateTime.TryParseExact(input, "d.M.yyy.H.m.s", null, System.Globalization.DateTimeStyles.None, out this.time_of_add));
        }
        public override void RemoveFilmInfo()
        {
            this.SetName("undefined");
            this.SetDescription("undefined");
            this.SetGenre("undefined");
            this.time_of_add = new(1, 1, 1, 0, 0, 0);
            Console.WriteLine("Данные удалены.");
        }
        public override void ChangeFilmInfo()
        {
            bool check = true;
            while (check)
            {
                int i;
                Console.WriteLine("Текущая информация о фильме: ");
                this.PrintFilmInfo();
                Console.WriteLine("Выберете поле которое хотите поменять:\n1.Название\n2.Жанр\n3.Описание\n4.Время добавления фильма в избранное ");
                while (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.WriteLine("Необходимо ввести число: ");
                }
                string input;
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Введите новое название фильма: ");
                        this.SetName(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Введите новый жанр фильма: ");
                        this.SetGenre(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Введите новое описание фильма: ");
                        this.SetDescription(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Введите новую дату добавления фильма в избранное: ");
                        do
                            input = Console.ReadLine();
                        while (!DateTime.TryParseExact(input, "d.M.yyy.H.m.s", null, System.Globalization.DateTimeStyles.None, out this.time_of_add));
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
    }
    class Blocked : Films
    {
        public string reason_of_block;
        public Blocked()
        {
            Console.WriteLine("Вызван конструктор наследника (Заблокированное) доп. класса по умолчанию");
            this.reason_of_block = "undefined";
        }
        public Blocked(string name, string description, string genre, string reason_of_block)
        {
            Console.WriteLine("Вызван конструктор наследника (Заблокированное) доп. класса с параметрами");
            this.SetName(name);
            this.SetDescription(description);
            this.SetGenre(genre);
            this.reason_of_block = reason_of_block;
        }
        public Blocked(Blocked b)
        {
            Console.WriteLine("Вызван конструктор наследника (Заблокированное) доп. класса копирования");
            this.reason_of_block = b.reason_of_block;
            this.SetName(b.GetName());
            this.SetGenre(b.GetGenre());
            this.SetDescription(b.GetDescription());
        }
        ~Blocked()
        {
            Console.WriteLine("Вызван деструктор наследника (Заблокированное) доп. класса");
            this.SetName("undefined");
            this.SetDescription("undefined");
            this.SetGenre("undefined");
            this.reason_of_block = "undefined";
        }
        public override void PrintFilmInfo() { Console.WriteLine($"Название заблокированного фильма: {this.GetName()}, жанр: {this.GetGenre()}\nОписание: {this.GetDescription()}\nПричина добавления фильма в заблокированное: {this.reason_of_block}"); }
        public override void AddFilmInfo()
        {
            Console.WriteLine("Введите название фильма: ");
            this.SetName(Console.ReadLine());
            Console.WriteLine("Введите жанр фильма: ");
            this.SetGenre(Console.ReadLine());
            Console.WriteLine("Введите описание фильма: ");
            this.SetDescription(Console.ReadLine());
            Console.WriteLine("Введите причину добавления фильма в заблокированное: ");
            reason_of_block = Console.ReadLine();

        }
        public override void RemoveFilmInfo()
        {
            this.SetName("undefined");
            this.SetDescription("undefined");
            this.SetGenre("undefined");
            this.reason_of_block = "undefined";
            Console.WriteLine("Данные удалены.");
        }
        public override void ChangeFilmInfo()
        {
            bool check = true;
            while (check)
            {
                int i;
                Console.WriteLine("Текущая информация о фильме: ");
                this.PrintFilmInfo();
                Console.WriteLine("Выберете поле которое хотите поменять:\n1.Название\n2.Жанр\n3.Описание\n4.Причина добавления фильма в заблокированное ");
                while (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.WriteLine("Необходимо ввести число: ");
                }
                string input;
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Введите новое название фильма: ");
                        this.SetName(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Введите новый жанр фильма: ");
                        this.SetGenre(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Введите новое описание фильма: ");
                        this.SetDescription(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Введите новую причину добавления фильма в заблокированное: ");
                        this.reason_of_block = Console.ReadLine();
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
    }
}
