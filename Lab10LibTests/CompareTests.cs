using Lab10Lib.Entities;
using Lab10Lib.Utilities;

namespace Lab10LibTests
{
    public class CompareTests
    {
        [Fact]
        public void CompareToTest()
        {
            // arrange
            Person person = new("surname2", "uname2", "p1", 12);
            Person support = new("surname2", "uname2", "p2", 12);
            Person someMan = new("surname2", "uname2", "p2", 13);
            Person yetAnotherMan = new("surname2", "uname2", "p2", 13);
            Student student = new("surname2", "uname1", null, 23, null, 4.3f, 3);

            // act
            int result1 = student.CompareTo(person);
            int result2 = person.CompareTo(support);
            int result3 = support.CompareTo(someMan);
            int result4 = someMan.CompareTo(yetAnotherMan);

            // assert
            Assert.True(result1 < 0);
            Assert.True(result2 < 0);
            Assert.True(result3 < 0);
            Assert.True(result4 == 0);
        }

        [Fact]
        public void IComparableTest()
        {
            // arrange
            Person person = new("surname2", "uname2", "p1", 12);
            Person support = new("surname2", "uname2", "p2", 12);
            Person someMan = new("surname2", "uname2", "p2", 13);
            Person yetAnotherMan = new("surname2", "uname2", "p2", 13);
            Student student = new("surname2", "uname1", null, 23, null, 4.3f, 3);

            PersonComparer comparer = new();

            // act
            int result1 = comparer.Compare(student, person);
            int result2 = comparer.Compare(person, support);
            int result3 = comparer.Compare(support, someMan);
            int result4 = comparer.Compare(someMan, yetAnotherMan);

            // assert
            Assert.True(result1 > 0);
            Assert.True(result2 < 0);
            Assert.True(result3 < 0);
            Assert.True(result4 == 0);
        }
    }
}