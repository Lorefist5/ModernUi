using ModernUi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUi.Data.Repositories.ORM
{
    public class UnitOfWorkORM : IUnitOfWork
    {
        public IUserRepository UserRepository { get; private set; }



        private readonly ApplicationDbContext _db;

        public UnitOfWorkORM(ApplicationDbContext db, IUserRepository userRepository)
        {
            _db = db;
            UserRepository = userRepository;
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
