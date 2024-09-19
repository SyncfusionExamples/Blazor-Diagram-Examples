using DiagramWithRemoteData.Models;
using Microsoft.EntityFrameworkCore;

namespace DiagramWithRemoteData.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        private readonly string _connectionString;

        public DataBaseContext(string connectionString)
        {
            _connectionString = GetConnectionString(connectionString);
        }

        public string GetConnectionString(string connection)
        {
            string Path = Environment.CurrentDirectory;
            string[] appPath = Path.Split(new string[] { "bin" }, StringSplitOptions.None);
            Console.WriteLine(appPath);
            connection = connection.Replace("|DataDirectory|/", appPath[0]);
            return connection;
        }

        public DbSet<Models.Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                
                                                                                                                                
        }
        public async Task SeedDataAsync()
        {
            // Clear the existing data
            Employees.RemoveRange(Employees);
            SaveChanges();

            // Add new data
            Employees.AddRange(new List<Employee>
            {
                new Employee { EmployeeID = 1, Name = "Andrew", ReportsTo = "", Designation = "CEO", Colour = "Blue" },
                new Employee { EmployeeID = 2, Name = "Nancy", ReportsTo = "1", Designation = "Product Manager", Colour = "Green" },
                new Employee { EmployeeID = 3, Name = "Janet", ReportsTo = "1", Designation = "Product Manager", Colour = "Green" },
                new Employee { EmployeeID = 4, Name = "Margaret", ReportsTo = "1", Designation = "Product Manager", Colour = "Green" },
                new Employee { EmployeeID = 5, Name = "Steven", ReportsTo = "1", Designation = "Product Manager", Colour = "Green" },
                new Employee { EmployeeID = 6, Name = "Michael", ReportsTo = "5", Designation = "Team Lead", Colour = "Orange" },
                new Employee { EmployeeID = 7, Name = "Robert", ReportsTo = "5", Designation = "Developer", Colour = "Brown" },
                new Employee { EmployeeID = 8, Name = "Anne", ReportsTo = "5", Designation = "Developer", Colour = "Brown" },
                new Employee { EmployeeID = 9, Name = "Laura", ReportsTo = "1", Designation = "HR", Colour = "Gray" },
                new Employee { EmployeeID = 10, Name = "John", ReportsTo = "5", Designation = "QA", Colour = "Pink" },
            });

            SaveChanges();
        }
    }
}
