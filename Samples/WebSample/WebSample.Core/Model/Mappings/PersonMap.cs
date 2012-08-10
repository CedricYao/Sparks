using FluentNHibernate.Mapping;

namespace WebSample.Core.Model.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("People");
            Not.LazyLoad();

            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Phone);
        }
    }
}