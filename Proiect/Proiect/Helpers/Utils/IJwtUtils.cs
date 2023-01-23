using Proiect.Models;

namespace Proiect.Helpers.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User User);
        public Guid ValidateJwtToken(string token);
    }
}
