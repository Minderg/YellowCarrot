﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public List<Recipe> Recipes { get; set; } = new();
    }
}
