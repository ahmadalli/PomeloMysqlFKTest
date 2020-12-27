using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKTest.Models
{
    public class Child
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Parent Parent { get; set; }
        public string ParentCode { get; set; }
        public Guid ParentId { get; set; }

        public class Configuration : IEntityTypeConfiguration<Child>
        {
            public void Configure(EntityTypeBuilder<Child> builder)
            {
                builder.ToTable(nameof(Child).Pluralize());
                builder.HasKey(x => x.Code);

                builder.HasOne(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentCode)
                    .IsRequired();
            }
        }
    }
}
