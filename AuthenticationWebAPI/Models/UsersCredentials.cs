using System.Collections.Generic;

namespace AuthenticationWebAPI.Models
{
    public class UsersCredentials
    {
        //Liste des utilisateurs
        public static Dictionary<string, User> AllUsers = new Dictionary<string, User>()
            {
               {"anis.youssef@soat.fr",new User(){Email="anis.youssef@soat.fr",Password="anis"} },
               {"test@test.fr",new User(){Email="test@test.fr",Password="test"} },
               {"toto@toto.fr",new User(){Email="toto@toto.fr",Password="toto"} },
               {"tata@tata.fr",new User(){Email="tata@tata.fr",Password="tata"} },

            };
    }
}
