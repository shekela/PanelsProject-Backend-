using PanelsProject_Backend.Entities;

namespace PanelsProject_Backend.Interfaces
{
    public interface ITokenService
    {
        string CreateTokenAdmin(Admin token);
    }
}
