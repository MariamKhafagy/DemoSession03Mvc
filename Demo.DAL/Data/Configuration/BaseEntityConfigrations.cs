using Demo.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configuration
{
    public class BaseEntityConfigrations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GetDate()");

        }
    }
}
