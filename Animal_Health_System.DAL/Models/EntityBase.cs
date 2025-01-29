using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Health_System.DAL.Models
{
    public class EntityBase
    {
        public int Id { get; set; } 
        // الحقول الخاصة بالتواريخ
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // الحقل الخاص بالحذف غير الفعلي
        public bool IsDeleted { get; set; }

        // تعيين قيمة CreatedAt عند الإنشاء
        public void SetCreatedAt(DateTime dateTime)
        {
            CreatedAt = dateTime;
        }

        // تعيين قيمة UpdatedAt عند التعديل
        public void SetUpdatedAt(DateTime dateTime)
        {
            UpdatedAt = dateTime;
        }
    }

}
