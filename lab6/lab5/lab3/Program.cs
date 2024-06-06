using System;
using System.Collections.Generic;

class Program
{
    static List<Film> films = new List<Film>();
    static TemplateArray<Film> filmArray = new TemplateArray<Film>(10);
    static TemplateArray<int> intArray = new TemplateArray<int>(10);
    static TemplateArray<char> charArray = new TemplateArray<char>(10);

    static void Main(string[] args)
    {
        PopulateIntArray();
        PopulateCharArray();

        while (true)
        {
            Console.WriteLine("1. Добавить фильм");
            Console.WriteLine("2. Добавить фильм в избранное");
            Console.WriteLine("3. Добавить фильм в заблокированное");
            Console.WriteLine("4. Удалить фильм");
            Console.WriteLine("5. Редактировать фильм");
            Console.WriteLine("6. Просмотр каталога");
            Console.WriteLine("7. Демонстрация атрибутов всех элементов");
            Console.WriteLine("16. Операторы сравнения в Favourite");
            Console.WriteLine("17. Операторы сравнения в Blocked");
            Console.WriteLine("18. Операторы == и =!");
            Console.WriteLine("19. Добавить фильм в массив");
            Console.WriteLine("20. Получить фильм из массива по индексу");
            Console.WriteLine("21. Найти фильм в массиве");
            Console.WriteLine("22. Минимальный и максимальный элемент");
            Console.WriteLine("23. Отсортировать по возрастанию");
            Console.WriteLine("0. Выход");
            Console.WriteLine("Сделайте свой выбор:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    return;
                case "19":
                    AddFilmToArray();
                    break;
                case "20":
                    GetFilmFromArray();
                    break;
                case "21":
                    FindFilmInArray();
                    break;
                case "22":
                    MinMaxFilmInArray();
                    break;
                case "23":
                    SortFilmArray();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }

    static void PopulateIntArray()
    {
        intArray.AddElement(5);
        intArray.AddElement(3);
        intArray.AddElement(8);
        intArray.AddElement(1);
        Console.WriteLine("Массив int после добавления элементов:");
        intArray.DisplayArray();

        intArray.sort();
        Console.WriteLine("Отсортированный массив int:");
        intArray.DisplayArray();
    }

    static void PopulateCharArray()
    {
        charArray.AddElement('b');
        charArray.AddElement('a');
        charArray.AddElement('d');
        charArray.AddElement('c');
        Console.WriteLine("Массив char после добавления элементов:");
        charArray.DisplayArray();

        charArray.sort();
        Console.WriteLine("Отсортированный массив char:");
        charArray.DisplayArray();
    }

    static void AddFilmToArray()
    {
        Console.WriteLine("Введите название фильма:");
        string addTitle = Console.ReadLine();
        Console.WriteLine("Введите год выпуска фильма:");
        int addYear = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите жанр фильма:");
        string addGenre = Console.ReadLine();
        Console.WriteLine("Введите описание фильма:");
        string addDescription = Console.ReadLine();

        Film addFilm = new Film(addTitle, addYear, addGenre, addDescription);
        filmArray.AddElement(addFilm); 
        Console.WriteLine("Фильм успешно добавлен в массив.");
    }

    static void GetFilmFromArray()
    {
        Console.WriteLine("Введите индекс фильма для получения:");
        int getIndex = int.Parse(Console.ReadLine());

        try
        {
            Film retrievedFilm = filmArray[getIndex];
            Console.WriteLine("Полученный фильм из массива:");
            Console.WriteLine(retrievedFilm);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Некорректный индекс фильма.");
        }
    }

    static void FindFilmInArray()
    {
        Console.WriteLine("Введите название фильма для поиска в массиве:");
        string searchTitle = Console.ReadLine();

        int foundIndex = filmArray.findItem(new Film(searchTitle, 0, "", ""));

        if (foundIndex != -1)
        {
            Console.WriteLine($"Фильм '{searchTitle}' найден на индексе {foundIndex}.");
        }
        else
        {
            Console.WriteLine($"Фильм '{searchTitle}' не найден в массиве.");
        }
    }

    static void MinMaxFilmInArray()
    {
        if (filmArray.Length == 0)
        {
            Console.WriteLine("Массив фильмов пуст.");
        }
        else
        {
            Film minFilm = filmArray.min();
            Console.WriteLine($"Минимальный фильм: {minFilm}");

            Film maxFilm = filmArray.max();
            Console.WriteLine($"Максимальный фильм: {maxFilm}");
        }
    }

    static void SortFilmArray()
    {
        filmArray.sort();
        Console.WriteLine("Массив фильмов отсортирован:");
        filmArray.DisplayArray();
    }
}
