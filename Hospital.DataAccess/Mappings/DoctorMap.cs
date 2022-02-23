namespace DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Domain;

    internal class DoctorMap : ClassMap<Doctor>
    {
        public DoctorMap()
        {
            this.Table("Doctors");

            this.Id(x => x.ID);

            this.Map(x => x.LastName)
                .Not.Nullable();

            this.Map(x => x.FirstName)
                .Not.Nullable();

            this.Map(x => x.Specialization)
                .Not.Nullable();

            this.Map(x => x.MiddleName)
                .Nullable();

            this.HasManyToMany(x => x.Pacients)
                .Cascade.Delete();
        }
    }
}
