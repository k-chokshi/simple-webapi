
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProvinceRepository Province { get; }
        public IPatientRepository Patient { get; }

        public UnitOfWork(IProvinceRepository provinceRepository, IPatientRepository patientRepository)
        {
            Province = provinceRepository;
            Patient = patientRepository; 
        }

    }
}
