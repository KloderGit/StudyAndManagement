using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BusinessLogic.Interfaces
{
    public interface IEducationBuilder
    {
        void GetExistingItems();
        void GetNewItems();
        void Updated();
    }
}
