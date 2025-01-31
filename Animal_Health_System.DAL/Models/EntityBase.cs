﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }


        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }

}
