﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowCarrot.Models
{
    class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; } = null!;
        public List<Recipe> Recipes { get; set; } = new();
    }
}