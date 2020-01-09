using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Domain;

namespace UserPosts.Services.UnitTest
{
    class FakeUserRepository : IUserRepository

    {
        public IList<UserPosts.Domain.User> GetAll()
        {
            throw new NotImplementedException();

        }

        public UserPosts.Domain.User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
