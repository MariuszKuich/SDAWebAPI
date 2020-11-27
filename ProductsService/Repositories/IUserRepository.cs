using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsOrdersService.Repositories
{
    public interface IUserRepository
    {
        bool isUserExists(string login, string md5Password);
    }
}
