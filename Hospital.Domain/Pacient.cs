namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hospital.Staff.Extensions;
    /// <summary>
    /// Пациент
    /// </summary>
    public class Pacient
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Pacient"/>.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="lastName"> Фамилия </param>
        /// <param name="firstName"> Имя </param>
        /// <param name="MiddleName"> Отчество </param>
        /// <param name="policie"> Номер полиса </param>
        /// <param name="doctors"> . </param>
        public Pacient(int id, string lastName, string firstName, string policie, string middleName, params Doctor[] doctors)
            : this(id, firstName, lastName, policie, middleName, new HashSet<Doctor>(doctors))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Pacient"/>.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="lastName"> Фамилия </param>
        /// <param name="firstName"> Имя </param>
        /// <param name="MiddleName"> Отчество </param>
        /// <param name="policie"> Номер полиса </param>
        /// <param name="doctors"> Множество врачей. </param>
        public Pacient(int id, string lastName, string firstName, string policie, string middleName = null, ISet<Doctor> doctors = null)
        {
            this.ID = id;
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
            this.Policie = policie.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(policie));
            this.MiddleName = middleName.TrimOrNull();

            foreach (var doctor in doctors ?? Enumerable.Empty<Doctor>())
            {
                this.Doctors.Add(doctor);
                doctor.AddPacient(this);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Pacient"/>.
        /// </summary>
        [Obsolete("For ORM", true)]
        protected Pacient()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual int ID { get; protected set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public virtual string LastName { get; protected set; }
        /// <summary>
        /// Имя
        /// </summary>
        public virtual string FirstName { get; protected set; }
        /// <summary>
        /// Специализация
        /// </summary>
        public virtual string Policie { get; protected set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public virtual string MiddleName { get; protected set; }
        /// <summary>
        /// Абоненты
        /// </summary>
        public virtual ISet<Doctor> Doctors { get; protected set; } = new HashSet<Doctor>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.FirstName} {this.LastName} {this.Policie} {this.MiddleName} {this.Doctors.Join()}".Trim();

    }
}
