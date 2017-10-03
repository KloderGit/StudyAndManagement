using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.DataBases.Infrastructure;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{
    public class AttestationDirector
    {
        IEducationBuilder builder;

        public AttestationDirector(IEducationBuilder builder)
        {
            this.builder = builder;
        }

        public void Build()
        {
            builder.GetNewItems();
            builder.Updated();
        }
    }

    public class AttestationBuilder : IEducationBuilder
    {

        IEnumerable<AttestationPOCO> serviceItems;
        List<Attestation> result = new List<Attestation>();

        List<AttestationPOCO> expextItems = new List<AttestationPOCO>();

        IEnumerable<Certification> certificationChidren = new List<Certification>();
        IEnumerable<CertificationType> certificationTypeChidren = new List<CertificationType>();

        public IUnitOfWorkEF database;

        public AttestationBuilder(IEnumerable<AttestationPOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }

        public void GetExistingItems()
        {
            throw new NotImplementedException();
        }

        public void GetNewItems()
        {
            var dbIt = database.Attestations.GetList().IncludeMultiple(m => m.Certification).IncludeMultiple(m => m.CertificationType).ToList();

            foreach (var item in serviceItems)
            {
                var dIt = dbIt.Where(d => d.Certification.Guid == item.Certification.Guid)
                              .Where(t => t.CertificationType.Guid == item.CertificationType.Guid);

                if (dIt.Count() == 0) { expextItems.Add(item); }
            }
        }

        public void UpdateCertificationChildren() {
            var certifications = serviceItems.Select(it => it.Certification)
                  .GroupBy(x => x.Guid)
                  .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                  .Select(x => x.Value);

            var certificationBuilder = new CertificationBuilder(certifications);
            var director = new CertificationDirector(certificationBuilder);

            director.Build();

            certificationChidren = certificationBuilder.GetResult();
        }

        public void UpdateCertificationTypeChildren()
        {
             var certificationsTypes = serviceItems.Select(it => it.CertificationType)
                  .GroupBy(x => x.Guid)
                  .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                  .Select(x => x.Value);

            var certificationTypesBuilder = new CertificationTypesBuilder(certificationsTypes);
            var director = new CertificationDirector(certificationTypesBuilder);

            director.Build();

            certificationTypeChidren = certificationTypesBuilder.GetResult();
        }

        public void Updated()
        {

            UpdateCertificationChildren();

            UpdateCertificationTypeChildren();


            foreach (var item in expextItems)
            {
                var cer = certificationChidren.FirstOrDefault(k => k.Guid == item.Certification.Guid);
                var typ = certificationTypeChidren.FirstOrDefault(t => t.Guid == item.CertificationType.Guid);

                if (cer != null && typ != null)
                {
                    database.Attestations.Add(new Attestation { Id = 0, CertificationId = cer.Id, CertificationTypeId = typ.Id, Updated = DateTime.Today });
                }
            }

            database.Save();

            var res = database.Attestations.GetList().IncludeMultiple(c => c.Certification).IncludeMultiple(t => t.CertificationType);

            foreach (var item in expextItems)
            {
                res = res.Where(ct => ct.Certification.Guid == item.Certification.Guid).Where(tp => tp.CertificationType.Guid == item.CertificationType.Guid);
            }

            result.AddRange(res.ToList());
        }

        public IEnumerable<Attestation> GetResult()
        {
            return result;
        }
    }
}
