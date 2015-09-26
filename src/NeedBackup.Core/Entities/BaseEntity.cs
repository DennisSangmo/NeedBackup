using System;

namespace NeedBackup.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}