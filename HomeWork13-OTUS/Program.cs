internal class Program
{
    public static void Main(string[] args)
    {
        var myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var myList2 = new List<Person>
        {
            new Person("John", 30),
            new Person("James", 60),
            new Person("Bill", 66),
            new Person("Artur", 54),
            new Person("Ivan", 15),
            new Person("Elena", 70),
            new Person("Liza", 55)
        };

        try
        {            
            Console.WriteLine("Результат 1:");
            var result1 = myList.Top(40).ToList();
            Console.WriteLine(String.Join(" ", result1) + "\n");

            Console.WriteLine("Результат 2:");
            var result2 = myList2.Top(50, person => person.Age).ToList();
            Console.WriteLine(String.Join(" ", result2));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }      
        
        Console.ReadKey();
    }
}

public static class MethodExtensions
{
    public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int x)
    {
        if (x < 1 || x > 100)
        {
            throw new ArgumentException("Введено неверное значение параметра");
        }
        double percent = x * 1.0 / 100;
        int count = (int)Math.Ceiling(collection.Count() * percent);
        return collection.OrderByDescending(x => x).Take(count);
    }
    
    public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int x, Func<T, int> func)
    {
        if (x < 1 || x > 100)
        {
            throw new ArgumentException("Введено неверное значение параметра");
        }
        double percent = x * 1.0 / 100;
        int count = (int)Math.Ceiling(collection.Count() * percent);            
        return collection.OrderByDescending(func).Take(count);
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"| {Name} - {Age} | ";
    }
} 