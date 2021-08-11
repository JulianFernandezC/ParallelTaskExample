﻿using System.ComponentModel.DataAnnotations;

namespace ParallelTaskApi.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
