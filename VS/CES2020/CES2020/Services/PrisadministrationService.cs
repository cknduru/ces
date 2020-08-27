using System;
using CES2020.Repositories;

namespace CES2020.Services
{
    public class PrisadministrationService
    {
        private readonly KonfigurationRepository konfigurationRepository;

        public PrisadministrationService()
        {
            this.konfigurationRepository = new KonfigurationRepository();
        }

        public void SetTelstarSegmentPris(float pris)
        {
            konfigurationRepository.SetTelstarSegmentPris((double) pris);
        }
    }
}
