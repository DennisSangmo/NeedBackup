using Castle.Components.DictionaryAdapter;

namespace NeedBackup.Core.Entities
{
    public class User : BaseEntity
    {
        public virtual string Username { get; protected set; }

        public User()
        {
        }

        public User(string username)
        {
            Username = username;
        }

        public virtual User Edit(string username)
        {
            Username = username;
            return this;
        }
    }
}