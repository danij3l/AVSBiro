namespace AVSBiro.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
    new Position { Id = 1, Name = "PLC Programmer", PayRank = 50000, Obsolete = false },
    new Position { Id = 2, Name = "Junior Developer", PayRank = 10000, Obsolete = false }
    );
            modelBuilder.Entity<Employee>().HasData(
                                               new Employee
                                               {
                                                   Id = 1,
                                                   Obsolete = false,
                                                   Brutto2 = 10000,
                                                   Contract = "Contract",
                                                   EmploymentEnded = false,
                                                   FirstName = "Nikola",
                                                   LastName = "Lovrić",
                                                   IBAN = "ibanNikola",
                                                   PaidOvertime = false,
                                                   PositionId = 1,
                                               },
            new Employee
            {
                Id = 2,
                Obsolete = false,
                Brutto2 = 10000,
                Contract = "Contract2",
                EmploymentEnded = false,
                FirstName = "Danijel",
                LastName = "Pavić",
                IBAN = "ibanDanijel",
                PaidOvertime = false,
                PositionId = 2
            }
            );

        }

        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<Position> Postions { get; set; }
    }
}
