using NeedBackup.Core.Entities;

namespace NeedBackup.Core.Persistance.Nhibernate.Maps
{
    public class UserMap : BaseEntityMap<User>
    {
        public UserMap()
        {
            Table("users");
            Map(x => x.Username);
        }
    }
}