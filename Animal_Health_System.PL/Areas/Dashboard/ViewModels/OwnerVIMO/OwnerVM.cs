﻿using Animal_Health_System.DAL.Models;

namespace Animal_Health_System.PL.Areas.Dashboard.ViewModels.OwnerVIMO
{
    public class OwnerVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}