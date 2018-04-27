using System.Collections.Generic;

namespace ConfidentialsWebAPI.Models
{
    public class UsersCredentials
    {
        //Liste des utilisateurs confidentiels
        public static List<User> ConfidentialUsers = new List<User>()
            {
                   {new User(){Email="anis.youssef@soat.fr" } },
                   {new User(){Email="test@test.fr" } },

            };
    }
}
