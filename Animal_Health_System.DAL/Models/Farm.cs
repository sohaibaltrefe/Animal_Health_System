﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Farm : EntityBase
    {
        public int Id { get; set; }



        public string Name { get; set; }

        public string Location { get; set; }
        [ForeignKey(nameof(Owner))]

        public int  OwnerId { get; set; }
        public Owner Owner { get; set; }

        public   ICollection<Animal> Animals { get; set; } = new List <Animal>();

        public   ICollection<Birth> Births { get; set; } = new List <Birth>();

        public   ICollection<FarmStaff> FarmStaffs { get; set; } = new List <FarmStaff>();
        public   ICollection<Appointment>  Appointments { get; set; } = new List <Appointment>();
        public   ICollection<BreedingReport> BreedingReports { get; set; } = new List <BreedingReport>();
        public   ICollection<Mating> Matings { get; set; } = new List <Mating>();

        public   ICollection<FarmHealthSummary>  FarmHealthSummaries { get; set; } = new List <FarmHealthSummary>();

    }
}
