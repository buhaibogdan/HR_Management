using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Premium.Users;
using System.Reflection;

namespace Premium
{
    public class UserFactory
    {
        Dictionary<string, Type> users;

        public UserFactory()
        {
            LoadTypesICanReturn();
        }

        public IUser CreateInstance(string userType)
        {
            Type t = GetTypeToCreate(userType);

            if (t == null)
            {
                return new NullUser();
            }
            return Activator.CreateInstance(t) as IUser;
        }

        private Type GetTypeToCreate(string userType)
        {
            foreach (var user in users)
            {
                if (user.Key.Contains(userType))
                {
                    return users[user.Key];
                }
            }
            return null;
        }

        private void LoadTypesICanReturn()
        {
            users = new Dictionary<string, Type>();
            Type[] typesInThisAssemply = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssemply)
            {
                if (type.GetInterface(typeof(IUser).ToString()) != null)
                {
                    users.Add(type.Name.ToLower(), type);
                }
            }
        }
    }
}