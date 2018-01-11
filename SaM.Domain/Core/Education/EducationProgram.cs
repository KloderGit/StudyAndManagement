﻿using SaM.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class EducationProgram : ServiceItem<EducationProgram>
    {
        public EducationProgram()
        {
            EducationalPlanList = new HashSet<EducationalPlan>();
        }

        public Int32 Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public DateTime AcceptDate { get; set; }
        public string ProgramType { get; set; }
        public string StudyType { get; set; }
        public Int32 Order { get; set; }

        public Int32? CategoryId { get; set; }
        //[PropertyAddForEqual]
        public virtual Category Category { get; set; }

        public Int32? EducationTypeId { get; set; }
        public virtual EducationType EducationType { get; set; }

        public virtual ICollection<EducationalPlan> EducationalPlanList { get; set; }

        public override bool EqualService(EducationProgram item)
        {
            var result = Guid == item.Guid &&
                         Title == item.Title &&
                         AcceptDate == item.AcceptDate &&
                         ProgramType == item.ProgramType &&
                         StudyType == item.StudyType ? true : false;
            return result;
        }




    }
}
