using SaM.BusinessLogic.Facades.Education;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BusinessLogic
{
    public class Education
    {
        public async Task<bool> Update()
        {
            Console.Write("Обновление категорий | ");
            var categories = await new CategoryFacade().Update();
            Console.WriteLine("готово - " + categories);


            Console.Write("Обновление типов обучния | ");
            var eduTypes = await new EducationTypeFacade().Update();
            Console.WriteLine("готово - " + eduTypes);


            Console.Write("Обновление сертификаций | ");
            var certifications = await new CertificationFacade().Update();
            Console.WriteLine("готово - " + categories);


            Console.Write("Обновление типов сертификаций | ");
            var certificationsTypes = await new CertificationTypeFacade().Update();
            Console.WriteLine("готово - " + certificationsTypes);


            Console.Write("Обновление дисциплин | ");
            var subjs = await new SubjectFacade().Update();
            Console.WriteLine("готово - " + subjs);


            Console.Write("Обновление прогрпамм | ");
            var progr = await new ProgramFacade().Update();
            Console.WriteLine("готово - " + progr);

            return true;
        }
    }
}
