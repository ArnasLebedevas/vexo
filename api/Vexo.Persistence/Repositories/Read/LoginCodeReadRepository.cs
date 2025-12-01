using Microsoft.EntityFrameworkCore;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Domain.Entities;

namespace Vexo.Persistence.Repositories.Read;

public class LoginCodeReadRepository(VexoDbContext context) : ReadRepository<LoginCode>(context), ILoginCodeReadRepository
{
    public async Task<LoginCode?> GetValidCodeAsync(Guid userId, string code) => 
        await context.LoginCodes.Where(x => x.UserId == userId && x.Code == code && !x.Used && x.ExpiresAt > DateTime.UtcNow).OrderByDescending(x => x.ExpiresAt).FirstOrDefaultAsync();
}
