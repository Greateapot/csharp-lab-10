using Lab10Lib.Entities;

namespace Lab10LibTests
{
    public class CopyTests
    {
        [Fact]
        public void PersonCopyTest()
        {
            // arrange
            Person p2 = new(
                "Будин",
                "Данил",
                "Батькович",
                19,
                new() { "Xeosha" }
            );

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
            Pupil p2 = new(
                "Будин",
                "Данил",
                "Батькович",
                19,
                new() { "Xeosha" },
                4.3f,
                123
            );

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
            Student p2 = new(
                "Будин",
                "Данил",
                "Батькович",
                19,
                new() { "Xeosha" },
                4.3f,
                123
            );

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
            PartTimeStudent p2 = new(
                "Будин",
                "Данил",
                "Батькович",
                19,
                new() { "Xeosha" },
                4.3f,
                123,
                "some-data-lol"
            );

            // act
            var p3 = p2.Clone();
            var p4 = p2.ShallowCopy();

            // assert
            Assert.False(p3.Equals(p2));
            Assert.True(p4.Equals(p2));
        }
    }
}