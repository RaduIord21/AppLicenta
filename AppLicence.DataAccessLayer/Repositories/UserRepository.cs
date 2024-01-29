using AppLicence.DataAccessLayer.Interfaces;
using AppLicence.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLicence.DataAccessLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AchieveHubContext context) : base(context)
        {
        }
    }
}
