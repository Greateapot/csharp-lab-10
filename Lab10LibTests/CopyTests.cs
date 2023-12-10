namespace Lab10LibTests
{
    public class CopyTests
    {
        [Fact]
        public void PersonCopyTest()
        {
            // arrange
            Person p1 = new("Михаил", 21);
            Person p2 = new("Вячеслав", 22, p1);

            // act
            var p3 = p2.Clone();
            var p4 = p2.ShallowCopy();

            // assert
            Assert.False(p3.Equals(p2));
            Assert.True(p4.Equals(p2));
        }

        [Fact]
        public void PupilCopyTest()
        {
            // arrange
            Pupil p1 = new("Михаил", 21, 3, 4.3f);
            Pupil p2 = new("Вячеслав", 22, 3, 4.3f, p1);

            // act
            var p3 = p2.Clone();
            var p4 = p2.ShallowCopy();

            // assert
            Assert.False(p3.Equals(p2));
            Assert.True(p4.Equals(p2));
        }

        [Fact]
        public void StudentCopyTest()
        {
            // arrange
            Student p1 = new("Михаил", 21, "lol-21-1b", 4.3f, 3);
            Student p2 = new("Вячеслав", 22, "lol-21-1b", 4.3f, 3, p1);

            // act
            var p3 = p2.Clone();
            var p4 = p2.ShallowCopy();

            // assert
            Assert.False(p3.Equals(p2));
            Assert.True(p4.Equals(p2));
        }

        [Fact]
        public void PartTimeStudentCopyTest()
        {
            // arrange
            PartTimeStudent p1 = new("Михаил", 21, "lol-21-1bz", 4.3f, 3, false);
            PartTimeStudent p2 = new("Вячеслав", 22, "lol-21-1bz", 4.3f, 3, false, p1);

            // act
            var p3 = p2.Clone();
            var p4 = p2.ShallowCopy();

            // assert
            Assert.False(p3.Equals(p2));
            Assert.True(p4.Equals(p2));
        }
    }
}