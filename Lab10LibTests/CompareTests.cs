namespace Lab10LibTests
{
    public class CompareTests
    {
        [Fact]
        public void CompareToTest()
        {
            // arrange
            Person person = new("uname3", 12);
            Student student = new("uname1", 23, "lol-21-2b", 4.3f, 3);
            SomeClass someClass = new("some teeeeeeeext");

            // act
            int result = student.CompareTo(person);
            void action() => person.CompareTo(someClass);

            // assert
            Assert.True(result < 0);
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void IComparableTest()
        {
            // arrange
            Person person = new("uname1", 12);
            Student student = new("uname2", 23, "lol-21-2b", 4.3f, 3);

            PersonComparer comparer = new();

            // act
            var result = comparer.Compare(student, person);

            // assert
            Assert.True(result > 0);
        }
    }
}