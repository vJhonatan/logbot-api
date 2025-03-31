    using logbot.Database;
    using logbot.Models;

    namespace logbot.Services
    {
        public class EmployeeService
        {
            private readonly AppDbContext _context;

            public EmployeeService(AppDbContext context)
            {
                _context = context;
            }

            public void newEmployee(EmployeeModel employee)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }

            public IEnumerable<EmployeeModel> GetAll()
            {
                return _context.Employees.ToList();
            }
        }
    }
