using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandomFactory.Models
{
    public class RangeEntity
    {
        [Key, ForeignKey(nameof(Value))]
        public int ValueId { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public ValueEntity Value { get; set; }
    }
}
