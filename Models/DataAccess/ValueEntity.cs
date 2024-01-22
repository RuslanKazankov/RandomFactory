using RandomFactory.Models.ValueType;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandomFactory.Models
{
    public class ValueEntity
    {
        [Key]
        public int ValueId { get; set; }
        [Required]
        public string Value { get; set; }
        public int Seed { get; set; }
        public int Step { get; set; }
        public int TypeId { get; set; }
        public virtual ValueTypeEntity Type { get; set; }
        public int? RangeId { get; set; }
        public virtual RangeEntity Range { get; set; }
    }
}
