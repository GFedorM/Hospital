namespace Hospital.DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Hospital.Domain;

    internal class PacientMap : ClassMap<Pacient>
    {
        public PacientMap()
        {
            this.Table("Pacients");

            this.Id(x => x.ID);

            this.Map(x => x.LastName)
                .Not.Nullable();

            this.Map(x => x.FirstName)
                .Not.Nullable();

            this.Map(x => x.Policie)
                .Not.Nullable();

            this.Map(x => x.MiddleName)
                .Nullable();

            this.HasManyToMany(x => x.Doctors)
                .Cascade.Delete()
                .Inverse();
        }
    }
}
