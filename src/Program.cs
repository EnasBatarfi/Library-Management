internal class Program
{
    private static void Main()
    {
        var user2 = new User("Bob", new DateTime(2023, 2, 1));
        var user10 = new User("Julia");
        Console.WriteLine(user2.Name);
        Console.WriteLine(user2.Id);
        Console.WriteLine(user2.CreatedDate);
        Console.WriteLine(user10.Name);
        Console.WriteLine(user10.Id);
        Console.WriteLine(user10.CreatedDate);
    }
}