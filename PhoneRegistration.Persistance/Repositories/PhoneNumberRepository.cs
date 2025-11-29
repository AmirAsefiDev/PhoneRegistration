using Microsoft.EntityFrameworkCore;
using PhoneRegistration.Application.Contracts.Persistence;
using PhoneRegistration.Domain;
using PhoneRegistration.Persistence.Context;

namespace PhoneRegistration.Persistence.Repositories;

public class PhoneNumberRepository : GenericRepository<PhoneNumber>, IPhoneNumberRepository
{
    private readonly PhoneRegistrationDbContext _context;

    public PhoneNumberRepository(PhoneRegistrationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByMobileAsync(string mobile)
    {
        var phoneNumber = await _context.PhoneNumbers.FirstOrDefaultAsync(p => p.Mobile == mobile);
        return phoneNumber != null;
    }
}