using Emplomania.Data.VO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.VO
{
    public class CourseVO : NomenclatorVO
    {
        public Guid? CategoryFK { get; set; }
        public string Details { get; set; }
        public string Duration { get; set; }
        public string Frequency { get; set; }
        public string Cost { get; set; }
        public string TimeToRegister { get; set; }
        public string Contact { get; set; }

        private CategoryVO category;
        public CategoryVO Category
        {
            get {
                return category;
            }
            set
            {
                category = value;
                CategoryFK = category?.Id;
            }
        }

    }
}
