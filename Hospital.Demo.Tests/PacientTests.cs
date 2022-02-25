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
            var doctor = new Doctor(1, "���������", "�����", "��������", "����������");
            var pacient = new Pacient(1, "������", "������", "12345", "�����������", doctor);
            var expected = "������ ������ 12345 ����������� ��������� ����� �������� ����������.";

            //act
            var actual = pacient.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptyDoctor_Success()
        {
            // arrange
            var pacient = new Pacient(1, "������", "�������", "67890", "������������");
            var expected = "������� ������ 67890 ������������";

            //act
            var actual = pacient.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptyDoctors_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = new Pacient(1, "������", "�������", "67890", "������������"));
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
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Pacient(1, "������", "�������", wrongPolicie, "������������"));
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
            var doctor = new Doctor(1, "���������", "�����", "��������", "����������");

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Pacient(1, "������", "�������", wrongPolicie, "������������"));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            // arrange
            var doctor = new Doctor(1, "���������", "�����", "��������", "����������");

            // act & assert
            Assert.DoesNotThrow(() => _ = new Pacient(1, "������", "������", "12345", "�����������", doctor));
        }
    }
}

