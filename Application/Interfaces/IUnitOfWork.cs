using System;
namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProvinceRepository Province { get; }
        IPatientRepository Patient { get; }

    }
}
    