using ConsoleIOLib;

namespace Lab10Lib
{
    public class Student : Person, IInit
    {

        public Student() { }

        public Student(
            string name,
            int age,
            string group,
            float rating,
            int course,
            Person? bestFriend = null 
        ) : base(name, age, bestFriend)
        {
            Group = group;
            Rating = rating;
            Course = course;
        }

        private string? group;

        public string Group
        {
            get => group ?? "--";
            set => group = (value.Length == 0)
                ? throw new ArgumentException("Невозможная группа")
                : value;
        }

        private float rating;

        public float Rating
        {
            get => rating;
            set => rating = (value < 0 || value > 5)
                ? throw new ArgumentException("Невозможный рейтинг")
                : value;
        }
        private int course;

        public int Course
        {
            get => course;
            set => course = (value < 1 || value > 6)
                ? throw new ArgumentException("Невозможный курс")
                : value;
        }

        public override void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public new void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj) =>
            obj is Student student
            && student.Name == Name
            && student.Age == Age
            && student.Group == Group
            && student.Rating == Rating
            && student.Course == Course
            && student.BestFriend == BestFriend;

        public override int GetHashCode() =>
            (Name, Age, Group, Rating, Course).GetHashCode();

        public new string GetString() =>
            $"Student(name: {Name}, age: {Age}, group: {Group}, rating: {Rating:F2}, course: {Course}, bestFriend: {(BestFriend == null ? "null" : BestFriend)})";

        public override string ToString() => GetString();

        public new void Init()
        {
            base.Init();
            Group = ConsoleIO.InputRaw("Введите группу: ");
            Rating = ConsoleIO.Input<float>(
                "Введите рейтинг (0.0 <= R <= 5.0): ",
                v => v < 0 || v > 5 ? "Указан невозможный рейтинг" : null
            );
            Course = ConsoleIO.Input<int>(
                "Введите курс (1 <= R <= 6): ",
                v => v < 1 || v > 6 ? "Указан невозможный курс" : null
            );
        }

        public new void RandomInit()
        {
            base.RandomInit();
            Group = RandomContent.GetGroup();
            Rating = RandomContent.GetRating();
            Course = RandomContent.GetCourse();
        }

        public override Student ShallowCopy()
            => (Student)MemberwiseClone();

        public override object Clone()
            => new Student(
                Name, 
                Age, 
                Group, 
                Rating, 
                Course,
                BestFriend != null
                    ? new Person(
                        BestFriend.Name,
                        BestFriend.Age
                    )
                    : null
            );
    }
}