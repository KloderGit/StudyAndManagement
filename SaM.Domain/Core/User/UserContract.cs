﻿using System;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces;

namespace SaM.Domain.Core.User
{
    public class UserContract : IServiceItem
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public double? Pay { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public DateTime? EducationStart { get; set; }
        public DateTime? EducationEnd { get; set; }
        public string Result { get; set; }

        public Int32 UserId { get; set; }
        public virtual User User { get; set; }

        public Guid StudentGUID { get; set; }

        public Int32 EducationProgramId { get; set; }
        public virtual EducationProgram EducationProgram { get; set; }

        public Int32? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public Int32? SubGroupId { get; set; }
        public virtual SubGroup SubGroup { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}