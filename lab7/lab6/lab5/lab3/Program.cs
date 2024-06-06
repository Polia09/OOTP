using System.Collections.Generic;
using System;

class Program
{
    static List<Film> films = new List<Film>();
    static TemplateArray<Film> filmArray = new TemplateArray<Film>(10);

    static void Main(string[] args)
    {
        
        try
        {
            GenerateIntException();
        }
        catch (IntException ex)
        {
            Console.WriteLine($"Перехвачено исключение IntException: {ex.Message}");
        }

        try
        {
            GenerateStringException();
        }
        catch (StringException ex)
        {
            Console.WriteLine($"Перехвачено исключение StringException: {ex.Message}");
        }

        
        try
        {
            GenerateStandardException();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Перехвачено исключение ArgumentException: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Перехвачено исключение InvalidOperationException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено общее исключение: {ex.Message}");
        }
        catch 
        {
            Console.WriteLine("Перехвачено неизвестное исключение.");
        }

        TemplateArray<int> intArray = new TemplateArray<int>(5);
        TemplateArray<char> charArray = new TemplateArray<char>(5);

        intArray.AddElement(10);
        intArray.AddElement(20);
        intArray.AddElement(30);

        charArray.AddElement('a');
        charArray.AddElement('b');
        charArray.AddElement('c');

        AddFilmToArray();
        AddFilmToArray();

        Console.WriteLine("\nСодержимое массива int:");
        intArray.DisplayArray();

        Console.WriteLine("\nСодержимое массива char:");
        charArray.DisplayArray();

        Console.WriteLine("\nСодержимое массива фильмов:");
        filmArray.DisplayArray();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить фильм");
            Console.WriteLine("2. Получить фильм из массива по индексу");
            Console.WriteLine("3. Найти фильм в массиве");
            Console.WriteLine("4. Минимальный и максимальный элемент");
            Console.WriteLine("5. Отсортировать массив");
            Console.WriteLine("6. Проверка исключений");
            Console.WriteLine("0. Выход");
            Console.WriteLine("Сделайте свой выбор:");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        AddFilmToArray();
                        break;
                    case "2":
                        GetFilmFromArray();
                        break;
                    case "3":
                        FindFilmInArray();
                        break;
                    case "4":
                        MinMaxFilmInArray();
                        break;
                    case "5":
                        SortFilmArray();
                        break;
                    case "6":
                        TestExceptions();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Перехвачено исключение на верхнем уровне: {ex.Message}");
            }
            catch 
            {
                Console.WriteLine("Перехвачено неизвестное исключение на верхнем уровне.");
            }
        }
    }

    static void GenerateIntException()
    {
        throw new IntException("Это исключение типа int.");
    }

    static void GenerateStringException()
    {
        throw new StringException("Это исключение типа string.");
    }

    static void GenerateStandardException()
    {
        throw new ArgumentException("Это стандартное исключение типа ArgumentException.");
    }

    static void AddFilmToArray()
    {
        try
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
        catch (FormatException ex)
        {
            Console.WriteLine($"Перехвачено исключение FormatException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение: {ex.Message}");
        }
    }

    static void GetFilmFromArray()
    {
        try
        {
            Console.WriteLine("Введите индекс фильма для получения:");
            int getIndex = int.Parse(Console.ReadLine());

            Film retrievedFilm = filmArray[getIndex];
            Console.WriteLine("Полученный фильм из массива:");
            Console.WriteLine(retrievedFilm);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Перехвачено исключение IndexOutOfRangeException: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Перехвачено исключение FormatException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение: {ex.Message}");
        }
    }

    static void FindFilmInArray()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение: {ex.Message}");
        }
    }

    static void MinMaxFilmInArray()
    {
        try
        {
            if (filmArray.Length == 0)
            {
                Console.WriteLine("Массив фильмов пуст.");
                return;
            }

            Film minFilm = filmArray.min();
            Film maxFilm = filmArray.max();

            Console.WriteLine($"Минимальный фильм: {minFilm}");
            Console.WriteLine($"Максимальный фильм: {maxFilm}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Перехвачено исключение InvalidOperationException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение: {ex.Message}");
        }
    }

    static void SortFilmArray()
    {
        try
        {
            filmArray.sort();
            Console.WriteLine("Массив фильмов отсортирован.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение: {ex.Message}");
        }
    }

    static void TestExceptions()
    {
        // Проверка исключений типа int и string
        try
        {
            GenerateIntException();
        }
        catch (IntException ex)
        {
            Console.WriteLine($"Перехвачено исключение IntException: {ex.Message}");
        }

        try
        {
            GenerateStringException();
        }
        catch (StringException ex)
        {
            Console.WriteLine($"Перехвачено исключение StringException: {ex.Message}");
        }

        // Проверка стандартных исключений
        try
        {
            GenerateStandardException();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Перехвачено исключение ArgumentException: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Перехвачено исключение InvalidOperationException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено общее исключение: {ex.Message}");
        }

        // Проверка локальной обработки исключений в методах
        try
        {
            AddFilmToArrayWithException();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение на верхнем уровне: {ex.Message}");
        }

        try
        {
            GetFilmFromArrayWithException();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение на верхнем уровне: {ex.Message}");
        }
    }

    
    static void AddFilmToArrayWithException()
    {
        try
        {
            // Искусственно вызванное исключение для тестирования     
            throw new FormatException("Тестовое исключение FormatException в AddFilmToArrayWithException.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Перехвачено исключение FormatException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение: {ex.Message}");
        }
    }

    static void GetFilmFromArrayWithException()
    {
        try
        {
            // Искусственно вызванное исключение для тестирования
            throw new IndexOutOfRangeException("Тестовое исключение IndexOutOfRangeException в GetFilmFromArrayWithException.");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Перехвачено исключение IndexOutOfRangeException: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Перехвачено исключение: {ex.Message}");
        }
    }
}