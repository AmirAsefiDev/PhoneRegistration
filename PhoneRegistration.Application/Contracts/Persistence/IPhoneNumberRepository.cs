using PhoneRegistration.Domain;

namespace PhoneRegistration.Application.Contracts.Persistence;

public interface IPhoneNumberRepository : IGenericRepository<PhoneNumber>
{
    Task<bool> ExistsByMobileAsync(string mobile);
}