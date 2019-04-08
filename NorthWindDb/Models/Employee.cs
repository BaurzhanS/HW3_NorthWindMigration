using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int ? ReportsTo { get; set; }
        public string PhotoPath { get; set; }

        public virtual Employee Supervisor { get; set; }
        public virtual ICollection<Employee> Subordinates { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Territory> Territories { get; set; }
    }

    public class EmployeeConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(p => p.EmployeeId);
            HasMany(p => p.Subordinates)
                .WithOptional(p => p.Supervisor)
                .HasForeignKey(p => p.ReportsTo);
            Property(p => p.Photo).HasColumnType("image");
            HasMany(p => p.Territories).WithMany(p => p.Employees).Map(p =>
            {
                p.MapLeftKey("EmployeeId");
                p.MapRightKey("TerritoryId");
                p.ToTable("EmployeeTerritories");
            });

        }
    }
}
