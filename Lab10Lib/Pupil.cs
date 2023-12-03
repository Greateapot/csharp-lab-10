using ConsoleIOLib;

namespace Lab10Lib
{
    public class Pupil : Person, IInit
    {
        public Pupil() { }

        public Pupil(
            string name,
            int age,
            int grade,
            float rating
        ) : base(name, age)
        {
            Grade = grade;
            Rating = rating;
        }

        private int grade;
        public int Grade
        {
            get => grade;
            set => grade = (value < 0 || value > 11)
                ? throw new ArgumentException("impos grade")
                : value;
        }

        private float rating;

        public float Rating
        {
            get => rating;
            set => rating = (value < 0 || value > 5)
                ? throw new ArgumentException("impos rating")
                : value;
        }

        public override void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public new void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj) =>
            obj != null
            && obj is Pupil pupil
            && pupil.Name == Name
            && pupil.Age == Age
            && pupil.Grade == Grade
            && pupil.Rating == Rating;

        public override int GetHashCode() =>
            (Name, Age, Grade, Rating).GetHashCode();

        public new string GetString() =>
            $"Pupil(name: {Name}, age: {Age}, grade: {Grade}, rating: {Rating:F2})";

        public override string ToString() => GetString();

        public new void Init()
        {
            base.Init();
            Grade = ConsoleIO.Input<int>(
                "Введите класс: ",
                v => v > 11 ? "Указан несуществующий класс" : null
            );
            Rating = ConsoleIO.Input<float>(
                "Введите рейтинг: ",
                v => v < 0 || v > 5 ? "Указан невозможный рейтинг" : null
            );
        }

        public new void RandomInit()
        {
            base.RandomInit();
            Grade = RandomContent.GetGrade();
            Rating = RandomContent.GetRating();
        }

        public override Pupil ShallowCopy()
            => (Pupil)MemberwiseClone();

        public override object Clone()
            => new Pupil(Name, Age, Grade, Rating);
    }
}