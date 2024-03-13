namespace ASP_HW_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            List<Person> persons = new();
            var r = new Random();
            for(int i =0; i < 5; i++)
            {
                persons.Add( new (Guid.NewGuid(), 
                                  $"name{i}", 
                                  $"last name{i}", 
                                  r.Next()*40+20, 
                                  $"email{i}@gmail.com"));
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsJsonAsync(persons);  
            });

            app.Run();
        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public String Email { get; set; }
        public Person(Guid id, String firstName, String lastName, int age, String email)
        {
            Age = age;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
