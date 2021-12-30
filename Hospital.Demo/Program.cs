namespace Demo
{
    using System;
    using System.Linq;
    using DataAccess;
    using DataAccess.Repositories;
    using Domain;

    internal class Program
    {
        /// <summary>
        /// Главный метод
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {
            var doctor = new Doctor(1, "Быстряков", "Павел", "терапевт", "Валерьевич");
            var doctor1 = new Doctor(2, "Кулакова", "Анна", "стоматолог");
            var doctor2 = new Doctor(3, "Кусяка", "Дмитрий", "невролог", "Валентинович");
            var doctor3 = new Doctor(4, "Черный", "Александр", "лор", "Максимович");


            var pacient = new Pacient(1, "Иванов", "Сергей", "12345", "Анатольевич", doctor);
            var pacient1 = new Pacient(2, "Петров", "Георгий", "67890", "Владимирович", doctor1);
            var pacient2 = new Pacient(3, "Одинцов", "Михаил", "54321", "Олегович", doctor2);


            Console.WriteLine($"{pacient} {doctor}");

            var settings = new Settings();

            settings.AddDatabaseServer(@"DESKTOP-SMJ2IL0\SQLEXPRESS");

            settings.AddDatabaseName("HospitalServer");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(pacient);
                session.Save(pacient1);
                session.Save(pacient2);

                session.Save(doctor);
                session.Save(doctor1);
                session.Save(doctor2);
                session.Save(doctor3);
                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                var repoPacient = new PacientRepository();
                Console.WriteLine("All pacients:");
                repoPacient.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));

                var repoDoctor = new DoctorRepository();
                Console.WriteLine("All doctors:");
                repoDoctor.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));
            }
        }
    }
}
