using ConsoleIOLib;

namespace Lab10Lib
{
    public class PartTimeStudent : Student, IInit
    {
        public PartTimeStudent() { }

        public PartTimeStudent(
            string name,
            int age,
            string group,
            float rating,
            int course,
            bool isShortenedProgram,
            Person? bestFriend = null
        ) : base(name, age, group, rating, course, bestFriend)
        {
            IsShortenedProgram = isShortenedProgram;
        }

        public bool IsShortenedProgram { get; set; }

        public override void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public new void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj) =>
            obj is PartTimeStudent partTimeStudent
            && partTimeStudent.Name == Name
            && partTimeStudent.Age == Age
            && partTimeStudent.Group == Group
            && partTimeStudent.Rating == Rating
            && partTimeStudent.Course == Course
            && partTimeStudent.IsShortenedProgram == IsShortenedProgram
            && partTimeStudent.BestFriend == BestFriend;

        public override int GetHashCode() =>
            (Name, Age, Group, Rating, Course, IsShortenedProgram).GetHashCode();

        public new string GetString() =>
            $"PartTimeStudent(name: {Name}, age: {Age}, group: {Group}, rating: {Rating:F2}, "
            + $"course: {Course}, isShortenedProgram: {IsShortenedProgram}, bestFriend: {(BestFriend == null ? "null" : BestFriend)})";

        public override string ToString() => GetString();

        public new void Init()
        {
            base.Init();
            IsShortenedProgram = ConsoleIO.Input<uint>(
                "Программа сокращенная?\n1. Да\n2. Нет\nВвод: ",
                v => v < 1 || v > 2 ? $"Нет опции под номером {v}" : null
            ) == 1;
        }

        public new void RandomInit()
        {
            base.RandomInit();
            IsShortenedProgram = RandomContent.GetBool();
        }

        public override PartTimeStudent ShallowCopy()
            => (PartTimeStudent)MemberwiseClone();

        public override object Clone()
            => new PartTimeStudent(
                Name,
                Age,
                Group,
                Rating,
                Course,
                IsShortenedProgram,
                BestFriend != null
                    ? new Person(
                        BestFriend.Name,
                        BestFriend.Age
                    )
                    : null
            );
    }
}