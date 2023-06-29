using INOW.API.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace INOW.API.Persistence
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap() 
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
            });

            Property(b => b.Name, x =>
            {
                x.Length(520);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.FamilyName, x =>
            {
                x.Length(520);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Email, x =>
            {
                x.Length(520);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Phone, x =>
            {
                x.Length(520);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Password, x =>
            {
                x.Length(520);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
        }
    }
}
