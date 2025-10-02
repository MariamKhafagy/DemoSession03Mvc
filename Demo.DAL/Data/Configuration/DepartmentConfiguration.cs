


namespace Demo.DAL.Data.Configuration
{

    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
       void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> builder) 
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.Description).HasColumnType("varchar(200)");

            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GetDate()");



        }


    }
}
