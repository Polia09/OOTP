using System;

class Film : IComparable<Film>
{
    public string Title { get; private set; }
    public int Year { get; private set; }
    public string Genre { get; private set; }
    public string Description { get; private set; }

    public Film(string title, int year, string genre, string description)
    {
        Title = title;
        Year = year;
        Genre = genre;
        Description = description;
    }

    public override string ToString()
    {
        return $"Название: {Title}, Год: {Year}, Жанр: {Genre}, Описание: {Description}";
    }

    public int CompareTo(Film other)
    {
        return this.Year.CompareTo(other.Year);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Film other = (Film)obj;
        return Title == other.Title && Year == other.Year && Genre == other.Genre && Description == other.Description;
    }

    public override int GetHashCode()
    {
        return Title.GetHashCode();
    }

    public static bool operator ==(Film left, Film right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Film left, Film right)
    {
        return !(left == right);
    }
}


class TemplateArray<T> where T : IComparable<T>
{
    private T[] internalArray;
    private int count;

    public TemplateArray(int size)
    {
        internalArray = new T[size];
        count = 0;
        Console.WriteLine($"Создан массив на {size} элементов типа {typeof(T).Name}");
    }

    public void AddElement(T value)
    {
        if (count == internalArray.Length)
        {
            Array.Resize(ref internalArray, internalArray.Length * 2);
            Console.WriteLine($"Размер массива увеличен до {internalArray.Length}");
        }

        internalArray[count] = value;
        count++;
    }

    public int findItem(T obj)
    {
        for (int i = 0; i < count; i++)
        {
            if (internalArray[i].Equals(obj))
            {
                return i;
            }
        }
        return -1;
    }

    public int Length
    {
        get { return count; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Индекс вышел за пределы массива");
            }
            return internalArray[index];
        }
        set
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Индекс вышел за пределы массива");
            }
            internalArray[index] = value;
        }
    }

    public T GetElement(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Индекс вышел за пределы массива");
        }
        return internalArray[index];
    }

    public T min()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Массив пуст");
        }

        T min = internalArray[0];
        for (int i = 1; i < count; i++)
        {
            if (internalArray[i].CompareTo(min) < 0)
            {
                min = internalArray[i];
            }
        }
        return min;
    }

    public T max()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Массив пуст");
        }

        T max = internalArray[0];
        for (int i = 1; i < count; i++)
        {
            if (internalArray[i].CompareTo(max) > 0)
            {
                max = internalArray[i];
            }
        }
        return max;
    }

    public void sort()
    {
        Array.Sort(internalArray, 0, count);
    }

    public void DisplayArray()
    {
        Console.WriteLine("Содержимое массива:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"internalArray[{i}] = {internalArray[i]}");
        }
    }
}

