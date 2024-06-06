using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab3
{

    abstract class Catalog
    {
        protected string name;
        protected int year;
        protected List<Catalog> catalogItems;


        public Catalog()
        {
            Console.WriteLine("Вызван конструктор Catalog без параметров");
            catalogItems = new List<Catalog>();
        }

        public Catalog(string name, int year)
        {
            Console.WriteLine($"Вызван конструктор Catalog({name}, {year})");
            this.name = name;
            this.year = year;
            catalogItems = new List<Catalog>();
        }



        public abstract void View();
        public abstract void AddFilm(Film film);
        public abstract void AddFilm(string title, int year, string genre, string description);
        public abstract void RemoveFilm(Film film);
        public abstract void RemoveFilm(string title);
        public abstract void EditFilm(Film film);
        public abstract void EditFilm(string title);
        public abstract void ViewCatalog();
        public abstract Film GetFilmByTitle(string title);
        public abstract void AddFilmToFavourite(Film film);



        public virtual void AddItem(Catalog item)
        {
            if (catalogItems != null)
            {
                if (!catalogItems.Contains(item))
                {
                    catalogItems.Add(item);
                }
                else
                {
                    Console.WriteLine("Элемент уже существует в списке");
                }
            }
            else
            {
                Console.WriteLine("Список не инициализирован");
            }
        }


        public void DisplayAttributesForAllItems()
        {
            if (catalogItems != null && catalogItems.Count > 0)
            {
                foreach (var item in catalogItems)
                {
                    item.DisplayAttributes();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }

        }

        public virtual void DisplayAttributes()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Year: {year}");
        }

        ~Catalog()
        {
            Console.WriteLine($"Вызван деструктор Catalog() для каталога {name}");
        }
    }

    class Favourite : Catalog
    {
        private int popularity;
        

        public Favourite() : base()
        {
            Console.WriteLine("Вызван конструктор Favourite без параметров");
            catalogItems = new List<Catalog>();
        }

        public Favourite(string name, int year) : base(name, year)
        {
            Console.WriteLine($"Вызван конструктор Favourite({name}, {year})");
        }

        public override void View() { }
        public override void AddFilm(Film film) { }
        public override void AddFilm(string title, int year, string genre, string description) { }
        public override void RemoveFilm(Film film) { }
        public override void RemoveFilm(string title) { }
        public override void EditFilm(Film film) { }
        public override void EditFilm(string title) { }
        public override void ViewCatalog() { }
        public override Film GetFilmByTitle(string title)
        {
            return null;
        }
        public override void AddFilmToFavourite(Film film)
        {
            AddFilm(film);
        }

        public static bool operator >(Favourite favourite1, Favourite favourite2)
        {
            return Convert.ToInt64(favourite1.year) > Convert.ToInt64(favourite2.year);
        }

        public static bool operator <(Favourite favourite1, Favourite favourite2)
        {
            return Convert.ToInt64(favourite1.year) < Convert.ToInt64(favourite2.year);
        }


        public static bool operator ==(Favourite favourite1, Favourite favourite2)
        {
            return Convert.ToInt64(favourite1.year)== Convert.ToInt64(favourite2.year);
        }

        public static bool operator !=(Favourite favourite1, Favourite favourite2)
        {
            return Convert.ToInt64(favourite1.year) != Convert.ToInt64(favourite2.year);
        }
        public string Show_Name()
        {
            return this.name;
        }


        public override void DisplayAttributes()
        {
            base.DisplayAttributes();
            Console.WriteLine($"Popularity: {popularity}");
        }

        ~Favourite()
        {
            Console.WriteLine("Вызван деструктор Favourite");
        }
    }

    class Blocked : Catalog
    {
        private string reason;

        public Blocked() : base()
        {
            Console.WriteLine("Вызван конструктор Blocked без параметров");
        }

        public Blocked(string name, int year) : base(name, year)
        {
            Console.WriteLine($"Вызван конструктор Blocked({name}, {year})");
        }

        public override void View() { }
        public override void AddFilm(Film film) { }
        public override void AddFilm(string title, int year, string genre, string description) { }
        public override void RemoveFilm(Film film) { }
        public override void RemoveFilm(string title) { }
        public override void EditFilm(Film film) { }
        public override void EditFilm(string title) { }
        public override void ViewCatalog() { }
        public override Film GetFilmByTitle(string title)
        {
            return null;
        }
        public override void AddFilmToFavourite(Film film)
        {
            AddFilm(film);
        }
        public static bool operator >(Blocked blocked1, Blocked blocked2)
        {
            return (long)blocked1.year > (long)blocked2.year;
        }

        public static bool operator <(Blocked blocked1, Blocked blocked2)
        {
            return (long)blocked1.year < (long)blocked2.year;
        }

        public static bool operator ==(Blocked blocked1, Blocked blocked2)
        {
            return (long)blocked1.year == (long)blocked2.year;
        }

        public static bool operator !=(Blocked blocked1, Blocked blocked2)
        {
            return (long)blocked1.year != (long)blocked2.year;
        }
        public string Show_Name()
        {
            return this.name;
        }



        public override void DisplayAttributes()
        {
            base.DisplayAttributes();
            Console.WriteLine($"Reason: {reason}");

        }

        ~Blocked()
        {
            Console.WriteLine("Вызван деструктор Blocked");
        }

    }
}
