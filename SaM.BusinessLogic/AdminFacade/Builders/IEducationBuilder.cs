using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{
    public interface IEducationBuilder
    {
        void GetExistingItems();
        void GetNewItems();
        void MarkAsUpdated();
    }
}
