using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsOrdersService.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool isUserExists(string login, string md5Password)
        {
                                                                        //password: tajne
            if (login.Equals("mariusz") && md5Password.ToLower().Equals("77f869401de682f60e0e749493ab793d"))
            {
                return true;
            }
            return false;
        }
    }
}
