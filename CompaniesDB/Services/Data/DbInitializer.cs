using CompaniesDataBase.Models.Entities;

namespace CompaniesDataBase.Services.Data
{
    public class DbInitializer
    {
        public static void Initialize(CompaniesContext context)
        {
            if (context.Companies.Any())
            {
                return; //DB has been seeded
            }

            var companies = new Company[]
            {
                new Company {Address = "405 N Jefferson Ave", City = "Iola", Name = "Jefferson & Co", Phone = "+1 111-222-5400", State = "Cansas" },
                new Company {Address = "21 S Country Rd", City = "Devon", Name = "Cofferman", Phone = "+1 777-555-5400", State = "Ohio"},
                new Company {Address = "207 W Randolph St", City = "Moran", Name = "Marmatohn", Phone = "+1 222-333-5400", State = "Alabama"}
            };
            context.Companies.AddRange(companies);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee {FirstName = "John", LastName = "Mccarthy", BirthDate = new DateOnly(1927, 9, 4), CompanyId = 1, Position = "Developer", Title = "Mr."},
                new Employee {FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1988, 3, 20), CompanyId = 2, Position = "CEO", Title = "Mr."},
                new Employee {FirstName = "Jane", LastName = "Smith", BirthDate = new DateOnly(1995, 7, 12), CompanyId = 3, Position = "Developer", Title = "Mrs."},
                new Employee {FirstName = "Michael", LastName = "Johnson", BirthDate = new DateOnly(1980, 11, 5), CompanyId = 1, Position = "Manager", Title = "Mr."},
                new Employee {FirstName = "Emily", LastName = "Williams", BirthDate = new DateOnly(1992, 6, 30), CompanyId = 2, Position = "Manager", Title = "Mrs."},
                new Employee {FirstName = "Christopher", LastName = "Brown", BirthDate = new DateOnly(1987, 9, 18), CompanyId = 3, Position = "Developer", Title = "Mr."},
                new Employee {FirstName = "Jessica", LastName = "Miller", BirthDate = new DateOnly(1998, 1, 25), CompanyId = 1, Position = "Manager", Title = "Mrs."},
                new Employee {FirstName = "Matthew", LastName = "Davis", BirthDate = new DateOnly(1984, 4, 8), CompanyId = 2, Position = "Worker", Title = "Mr."},
                new Employee {FirstName = "Ashley", LastName = "Wilson", BirthDate = new DateOnly(1991, 12, 14), CompanyId = 3, Position = "CEO", Title = "Mrs."},
                new Employee {FirstName = "David", LastName = "Martinez", BirthDate = new DateOnly(1996, 8, 22), CompanyId = 1, Position = "Worker" , Title = "Mr."},
                new Employee { FirstName = "Sarah", LastName = "Taylor", BirthDate = new DateOnly(1989, 5, 10), CompanyId = 2, Position = "Worker", Title = "Mrs."}
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            var notes = new Note[]
            {
                new Note {InvoiceNumber = 1001, CompanyId = 1, EmployeeId = 1},
                new Note {InvoiceNumber = 1002, CompanyId = 2, EmployeeId = 2},
                new Note {InvoiceNumber = 1003, CompanyId = 3, EmployeeId = 3},
                new Note {InvoiceNumber = 1004, CompanyId = 1, EmployeeId = 4},
                new Note {InvoiceNumber = 1005, CompanyId = 2, EmployeeId = 5},
                new Note {InvoiceNumber = 1006, CompanyId = 3, EmployeeId = 6},
                new Note {InvoiceNumber = 1007, CompanyId = 1, EmployeeId = 7},
                new Note {InvoiceNumber = 1008, CompanyId = 2, EmployeeId = 8},
                new Note {InvoiceNumber = 1009, CompanyId = 3, EmployeeId = 9},
                new Note {InvoiceNumber = 1010, CompanyId = 1, EmployeeId = 10},
                new Note {InvoiceNumber = 1001, CompanyId = 1, EmployeeId = 1},
                new Note {InvoiceNumber = 1002, CompanyId = 2, EmployeeId = 2},
                new Note {InvoiceNumber = 1003, CompanyId = 3, EmployeeId = 3},
                new Note {InvoiceNumber = 1004, CompanyId = 1, EmployeeId = 4},
                new Note {InvoiceNumber = 1005, CompanyId = 2, EmployeeId = 5},
                new Note {InvoiceNumber = 1006, CompanyId = 3, EmployeeId = 6},
                new Note {InvoiceNumber = 1007, CompanyId = 1, EmployeeId = 7},
                new Note {InvoiceNumber = 1008, CompanyId = 2, EmployeeId = 8},
                new Note {InvoiceNumber = 1009, CompanyId = 3, EmployeeId = 9},
                new Note {InvoiceNumber = 1010, CompanyId = 1, EmployeeId = 10},
                new Note {InvoiceNumber = 1001, CompanyId = 1, EmployeeId = 1},
                new Note {InvoiceNumber = 1002, CompanyId = 2, EmployeeId = 2},
                new Note {InvoiceNumber = 1003, CompanyId = 3, EmployeeId = 3},
                new Note {InvoiceNumber = 1004, CompanyId = 1, EmployeeId = 4},
                new Note {InvoiceNumber = 1005, CompanyId = 2, EmployeeId = 5},
                new Note {InvoiceNumber = 1006, CompanyId = 3, EmployeeId = 6},
                new Note {InvoiceNumber = 1007, CompanyId = 1, EmployeeId = 7},
                new Note {InvoiceNumber = 1008, CompanyId = 2, EmployeeId = 8},
                new Note {InvoiceNumber = 1009, CompanyId = 3, EmployeeId = 9},
                new Note {InvoiceNumber = 1010, CompanyId = 1, EmployeeId = 10}
            };
            context.Notes.AddRange(notes);
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 1), StoreCity = "New York"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 2), StoreCity = "Los Angeles"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 3), StoreCity = "Chicago"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 4), StoreCity = "Houston"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 5), StoreCity = "Miami"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 6), StoreCity = "San Francisco"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 7), StoreCity = "Seattle"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 8), StoreCity = "Boston"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 9), StoreCity = "Dallas"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 10), StoreCity = "Denver"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 1), StoreCity = "New York"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 2), StoreCity = "Los Angeles"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 3), StoreCity = "Chicago"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 4), StoreCity = "Houston"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 5), StoreCity = "Miami"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 6), StoreCity = "San Francisco"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 7), StoreCity = "Seattle"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 8), StoreCity = "Boston"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 9), StoreCity = "Dallas"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 10), StoreCity = "Denver"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 1), StoreCity = "New York"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 2), StoreCity = "Los Angeles"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 3), StoreCity = "Chicago"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 4), StoreCity = "Houston"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 5), StoreCity = "Miami"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 6), StoreCity = "San Francisco"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 7), StoreCity = "Seattle"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 8), StoreCity = "Boston"},
                new Order {CompanyId = 3, OrderDate = new DateTime(2023, 7, 9), StoreCity = "Dallas"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 10), StoreCity = "Denver"}
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();



        }
    }
}
