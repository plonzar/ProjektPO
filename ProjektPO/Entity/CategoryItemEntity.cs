﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO.Model
{
    public class CategoryItemEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
