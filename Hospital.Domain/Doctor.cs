namespace Hospital.Domain
{
    using System;
    using System.Collections.Generic;
    using Hospital.Staff.Extensions;
    
    public class Doctor : IEquatable<Doctor>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Doctor"/>
        /// </summary>
        /// <param name="id"> Идентефикатор </param>
        /// <param name="lastName"> Фамилия </param>
        /// <param name="firstName"> Имя </param>
        /// <param name="MiddleName"> Отчество </param>
        /// <param name="specialization"> Специализация </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В случае если <paramref name="lastName"/> или <paramref name="firstName"/> или <paramref name="specialization"/> <see langword="null"/>, 
        /// пустая строка или строка, содержащая только пробельные символы.
        /// </exception>
        public Doctor(int id, string lastName, string firstName, string specialization, string middleName = null)
        {
            this.ID = id;
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
            this.Specialization = specialization.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(specialization));
            this.MiddleName = middleName.TrimOrNull();
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Doctor"/>
        /// </summary>
        [Obsolete("For ORM", true)]
        protected Doctor()
        {
        }
        /// <summary>
        /// Уникальный идентефикатор
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
        public virtual string Specialization { get; protected set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public virtual string MiddleName { get; protected set; }

        /// <summary>
        /// Полная информация о враче
        /// </summary>
        public virtual string FullInfDoctor => $"{this.LastName} {this.FirstName} {this.Specialization} {this.MiddleName}.".Trim();

        /// <summary>
        /// Множество пациентов
        /// </summary>
        public virtual ISet<Pacient> Pacients { get; protected set; } = new HashSet<Pacient>();

        /// <summary>
        /// Метод, добавляющий пациента доктору.
        /// </summary>
        /// <param name="pacient"> Добавляем пациента. </param>
        /// <returns>
        /// Флаг успешности выполнения операции:
        /// <see langword="true"/> – пациент был успешно добавлен,
        /// <see langword="false"/> в противном случае.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="pacient"/> – <see langword="null"/>.
        /// </exception>
        public virtual bool AddPacient(Pacient pacient)
        {
            return pacient == null
                ? throw new ArgumentNullException(nameof(pacient))
                : this.Pacients.Add(pacient);
        }

        public override string ToString() => this.FullInfDoctor;

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || this.Equals(obj as Doctor));
        }

        public virtual bool Equals(Doctor other)
        {
            return !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || this.ID == other.ID);
        }

        public override int GetHashCode() => this.ID;
    }
}

