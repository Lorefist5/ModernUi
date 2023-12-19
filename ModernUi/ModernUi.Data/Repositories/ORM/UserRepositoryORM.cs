using ModernUi.Data.Model;
using ModernUi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUi.Data.Repositories.ORM
{
    public class UserRepositoryORM : GenericRepositoryORM<User>, IUserRepository
    {
        public UserRepositoryORM(ApplicationDbContext db) : base(db)
        {
        }

        public void Update(User user)
        {
            _db.Update(user);
        }
    }
}
