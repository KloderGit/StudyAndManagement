using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.POCO
{

    /// <summary>
    /// Вид Проверки \ Аттестации - [ Экзамен \ Тест \ Зачет ]
    /// </summary>
    public class CertificationPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public ICollection<CertificationTypePOCO> AssessmentTypeList { get; set; }
    }
}
