using RandomFactory.Models.ValueType;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace RandomFactory.Models.DataAccess
{
    public class ValueDbContext : DbContext
    {
        public ValueDbContext(): base("DefaultConnection")
        {

        }
        public DbSet<ValueEntity> Values { get; set; }
        public DbSet<RangeEntity> Ranges { get; set; }
        public DbSet<ValueTypeEntity> ValueTypes { get; set; }
        private void ImplementValueTypes()
        {
            if (ValueTypes.ToList().Count() == 0) {
                ValueTypes.Add(new ValueTypeEntity { Name = "Int" });
                ValueTypes.Add(new ValueTypeEntity { Name = "Double" });
                ValueTypes.Add(new ValueTypeEntity { Name = "Percent" });
                SaveChanges();
            }
        }
        public void LoadAll()
        {
            Values.Load();
            Ranges.Load();
            ValueTypes.Load();
            ImplementValueTypes();
        }
    }
}
