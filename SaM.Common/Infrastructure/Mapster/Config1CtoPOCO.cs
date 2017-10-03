using Mapster;
using SaM.Common.DTO;
using SaM.Common.POCO;
using SaM.Domain.Core.Education;
using SoapService1full;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure.Mapster
{
    public class Config1CtoPOCO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<formControl, CertificationPOCO>()
                .Map(dest => dest.Guid, src => src.GUIDFormControl)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<CertificationDTO, CertificationPOCO>()
                .Ignore(it => it.Id);

            config.NewConfig<CertificationPOCO, Certification>()
                .Ignore( it => it.Id);


            config.NewConfig<ViewAttestation, CertificationTypePOCO>()
                .Map(dest => dest.Guid, src => src.GUIDViewAttestation)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<CertificationTypePOCO, CertificationType>()
                .Ignore(it => it.Id);
        }
    }
}
