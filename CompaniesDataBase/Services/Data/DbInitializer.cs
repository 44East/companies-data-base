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

            var titles = new EmployeeSalutation[]
            {
                new EmployeeSalutation { Salutation = "Mr."},
                new EmployeeSalutation { Salutation = "Mrs."}
            };
            context.Titles.AddRange(titles);
            context.SaveChanges();

            var positions = new EmployeePosition[]
            {
                new EmployeePosition {Title = "CEO"},
                new EmployeePosition {Title = "Developer"},
                new EmployeePosition {Title = "Manager"},
                new EmployeePosition {Title = "Worker"}
            };
            context.Positions.AddRange(positions);
            context.SaveChanges();

            var companies = new Company[]
            {
                new Company { Address = "405 N Jefferson Ave", City = "Iola", Name = "Jefferson & Co", Phone = "+1 111-222-5400", State = "Cansas" },
                new Company { Address = "21 S Country Rd", City = "Devon", Name = "Cofferman", Phone = "+1 777-555-5400", State = "Ohio"},
                new Company { Address = "207 W Randolph St", City = "Moran", Name = "Marmatohn", Phone = "+1 222-333-5400", State = "Alabama"}
            };
            context.Companies.AddRange(companies);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee {FirstName = "John", LastName = "Mccarthy", BirthDate = new DateTime(1927, 9, 4), CompanyId = 0, PositionId = 1, TitleId = 0},
                new Employee {FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1988, 3, 20), CompanyId = 0, PositionId = 0, TitleId = 0},
                new Employee {FirstName = "Jane", LastName = "Smith", BirthDate = new DateTime(1995, 7, 12), CompanyId = 1, PositionId = 1, TitleId = 1},
                new Employee {FirstName = "Michael", LastName = "Johnson", BirthDate = new DateTime(1980, 11, 5), CompanyId = 2, PositionId = 2, TitleId = 0},
                new Employee {FirstName = "Emily", LastName = "Williams", BirthDate = new DateTime(1992, 6, 30), CompanyId = 0, PositionId = 3, TitleId = 1},
                new Employee {FirstName = "Christopher", LastName = "Brown", BirthDate = new DateTime(1987, 9, 18), CompanyId = 1, PositionId = 0, TitleId = 0},
                new Employee {FirstName = "Jessica", LastName = "Miller", BirthDate = new DateTime(1998, 1, 25), CompanyId = 2, PositionId = 1, TitleId = 1},
                new Employee {FirstName = "Matthew", LastName = "Davis", BirthDate = new DateTime(1984, 4, 8), CompanyId = 0, PositionId = 2, TitleId = 0},
                new Employee {FirstName = "Ashley", LastName = "Wilson", BirthDate = new DateTime(1991, 12, 14), CompanyId = 1, PositionId = 3, TitleId = 1},
                new Employee {FirstName = "David", LastName = "Martinez", BirthDate = new DateTime(1996, 8, 22), CompanyId = 2, PositionId = 0, TitleId = 0},
                new Employee { FirstName = "Sarah", LastName = "Taylor", BirthDate = new DateTime(1989, 5, 10), CompanyId = 0, PositionId = 1, TitleId = 1}
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            var notes = new Note[]
            {
                new Note {InvoiceNumber = 1001, CompanyId = 0, EmployeeId = 0},
                new Note {InvoiceNumber = 1002, CompanyId = 1, EmployeeId = 1},
                new Note {InvoiceNumber = 1003, CompanyId = 2, EmployeeId = 2},
                new Note {InvoiceNumber = 1004, CompanyId = 0, EmployeeId = 3},
                new Note {InvoiceNumber = 1005, CompanyId = 1, EmployeeId = 4},
                new Note {InvoiceNumber = 1006, CompanyId = 2, EmployeeId = 5},
                new Note {InvoiceNumber = 1007, CompanyId = 0, EmployeeId = 6},
                new Note {InvoiceNumber = 1008, CompanyId = 1, EmployeeId = 7},
                new Note {InvoiceNumber = 1009, CompanyId = 2, EmployeeId = 8},
                new Note {InvoiceNumber = 1010, CompanyId = 0, EmployeeId = 9}
            };
            context.Notes.AddRange(notes);
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order {CompanyId = 0, OrderDate = new DateTime(2023, 7, 1), StoreCity = "New York"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 2), StoreCity = "Los Angeles"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 3), StoreCity = "Chicago"},
                new Order {CompanyId = 0, OrderDate = new DateTime(2023, 7, 4), StoreCity = "Houston"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 5), StoreCity = "Miami"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 6), StoreCity = "San Francisco"},
                new Order {CompanyId = 0, OrderDate = new DateTime(2023, 7, 7), StoreCity = "Seattle"},
                new Order {CompanyId = 1, OrderDate = new DateTime(2023, 7, 8), StoreCity = "Boston"},
                new Order {CompanyId = 2, OrderDate = new DateTime(2023, 7, 9), StoreCity = "Dallas"},
                new Order {CompanyId = 0, OrderDate = new DateTime(2023, 7, 10), StoreCity = "Denver"}
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();


        }
    }
}
