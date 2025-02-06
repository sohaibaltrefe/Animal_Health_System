﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class Mating : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public DateTime MatingDate { get; set; }  

        public string Notes { get; set; }
        // العلاقة مع المزرعة
        [ForeignKey(nameof(Farm))]
        public int  FarmId { get; set; }
        public Farm Farm { get; set; }

        // العلاقة مع الحيوان الذكر
        [ForeignKey(nameof(MaleAnimal))]
        public int  MaleAnimalId { get; set; }
        public Animal MaleAnimal { get; set; }

        // العلاقة مع الحيوان الأنثى
        [ForeignKey(nameof(FemaleAnimal))]
        public int  FemaleAnimalId { get; set; }
        public Animal FemaleAnimal { get; set; }

        // التقارير المرتبطة بالتزاوج
        public ICollection<BreedingReport> BreedingReports { get; set; } = new List <BreedingReport>();
    }

}
