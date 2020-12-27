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
    public class Parent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Child> Children { get; set; } = new List<Child>();

        public class Configuration : IEntityTypeConfiguration<Parent>
        {
            public void Configure(EntityTypeBuilder<Parent> builder)
            {
                builder.ToTable(nameof(Parent).Pluralize());
                builder.HasKey(x => x.Code);
            }
        }
    }
}
