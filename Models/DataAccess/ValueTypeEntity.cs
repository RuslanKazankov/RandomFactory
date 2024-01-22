using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandomFactory.Models.ValueType
{
    public class ValueTypeEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<string> Values { get; set; } = new List<string>();
    }
}
