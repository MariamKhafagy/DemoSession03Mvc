

using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared.Enums;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;

namespace Demo.DAL.Data.Configuration
{
    public class EmployeeConfiguration :BaseEntityConfigrations<Employee> ,IEntityTypeConfiguration<Employee>
    {
        public  new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");

            builder.Property(e => e.Gender).HasConversion(
                (empGender) => empGender.ToString(),
                (gender) => (Gender)Enum.Parse(typeof(Gender), gender)); //when u return as a string the type is GenderType



            builder.Property(e => e.EmployeeType).HasConversion(
                (empType) => empType.ToString() //Sve Label Do not save the Value 
                , (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type)); //when u return as a string the type is EmpType

            base.Configure(builder);
        }
    }

}
