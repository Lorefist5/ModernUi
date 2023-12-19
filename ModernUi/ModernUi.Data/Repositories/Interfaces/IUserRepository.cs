using Microsoft.EntityFrameworkCore.Update.Internal;
using ModernUi.Data.Model;


namespace ModernUi.Data.Repositories.Interfaces
{
    public interface IUserRepository : IGeneric<User>
    {
        public void Update(User user);
    }
}