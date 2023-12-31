using Lab10Lib.Entities;

namespace Lab10LibTests
{
    public class PropertiesTests
    {
        [Fact]
        public void PersonName()
        {
            // arrange
            Person person = new();

            // act
            void action1() => person.Name = "";

            // assert
            Assert.Throws<ArgumentException>(action1);
        }

        [Fact]
        public void PersonAge()
        {
            // arrange
            Person person = new();

            // act
            void action1() => person.Age = 121;
            void action2() => person.Age = 0;

            // assert
            Assert.Throws<ArgumentException>(action1);
            Assert.Throws<ArgumentException>(action2);
        }

        [Fact]
        public void PupilGrade()
        {
            // arrange
            Pupil pupil = new();

            // act
            void action2() => pupil.SchoolID = 0;

            // assert
            Assert.Throws<ArgumentException>(action2);
        }

        [Fact]
        public void PupilRating()
        {
            // arrange
            Pupil pupil = new();

            // act
            void action1() => pupil.Rating = +5.00001f;
            void action2() => pupil.Rating = -0.00001f;

            // assert
            Assert.Throws<ArgumentException>(action1);
            Assert.Throws<ArgumentException>(action2);
        }

        [Fact]
        public void StudentCourse()
        {
            // arrange
            Student student = new();

            // act
            void action1() => student.UniversityID = 0;

            // assert
            Assert.Throws<ArgumentException>(action1);
        }

        [Fact]
        public void StudentRating()
        {
            // arrange
            Student student = new();

            // act
            void action1() => student.Rating = +5.00001f;
            void action2() => student.Rating = -0.00001f;

            // assert
            Assert.Throws<ArgumentException>(action1);
            Assert.Throws<ArgumentException>(action2);
        }
    }
}