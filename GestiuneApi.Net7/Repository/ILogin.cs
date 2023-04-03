using System.Collections.Generic;
using System.Threading.Tasks;
using GestiuneSaliNET7.Models;

namespace GestiuneSaliNET7.Repository
{
        public interface ILogin
        {
            Task<IEnumerable<UserModel>> getuser();
            Task<UserModel> AuthenticateUser(string username, string passcode);
        }

}
