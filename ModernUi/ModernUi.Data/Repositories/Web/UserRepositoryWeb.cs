using ModernUi.Data.Model;
using ModernUi.Data.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModernUi.Data.Repositories.Web
{
    public class UserRepositoryWeb : GenericRepositoryWeb<User>, IUserRepository
    {
        public UserRepositoryWeb(HttpClient httpClient, string apiEndpoint) : base(httpClient, apiEndpoint)
        {
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
