using FluentNHibernate.Mapping;
using NeedBackup.Core.Entities;

namespace NeedBackup.Core.Persistance.Nhibernate.Maps
{
    public class BaseEntityMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
        }
    }
}