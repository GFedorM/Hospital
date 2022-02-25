namespace Hospital.Demo.Tests
{
    using System;
    using NUnit.Framework;
    using Hospital.Domain;

    [TestFixture]
    public class PacientTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var doctor = new Doctor(1, "Быстряков", "Павел", "терапевт", "Валерьевич");
            var pacient = new Pacient(1, "Иванов", "Сергей", "12345", "Анатольевич", doctor);
            var expected = "Иванов Сергей 12345 Анатольевич Быстряков Павел терапевт Валерьевич.";

            //act
            var actual = pacient.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptyDoctor_Success()
        {
            // arrange
            var pacient = new Pacient(1, "Петров", "Георгий", "67890", "Владимирович");
            var expected = "Георгий Петров 67890 Владимирович";

            //act
            var actual = pacient.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptyDoctors_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = new Pacient(1, "Петров", "Георгий", "67890", "Владимирович"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
        public void Ctor_WrongDataNullNameEmptyDoctors_Fail(string wrongPolicie)
        {
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Pacient(1, "Петров", "Георгий", wrongPolicie, "Владимирович"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
        public void Ctor_WrongDataNullNameEmptyDoctor_Fail(string wrongPolicie)
        {
            // arrange
            var doctor = new Doctor(1, "Быстряков", "Павел", "терапевт", "Валерьевич");

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Pacient(1, "Петров", "Георгий", wrongPolicie, "Владимирович"));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            // arrange
            var doctor = new Doctor(1, "Быстряков", "Павел", "терапевт", "Валерьевич");

            // act & assert
            Assert.DoesNotThrow(() => _ = new Pacient(1, "Иванов", "Сергей", "12345", "Анатольевич", doctor));
        }
    }
}

