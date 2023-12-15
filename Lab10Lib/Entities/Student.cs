using ConsoleIOLib;
using Lab10Lib.Utilities;


namespace Lab10Lib.Entities
{
    public class Student : Person, IEquatable<Student>
    {
        protected float? rating;
        protected uint? universityID;

        public float Rating
        {
            get => rating ?? 0;
            set => rating = value >= 0 && value <= 5
                ? value
                : throw new ArgumentException("invalid rating (not in range(0.0, 5.0))");
        }

        public uint UniversityID
        {
            get => universityID ?? 0;
            set => universityID = value > 0
                ? value
                : throw new ArgumentException("invalid university id (zero)");
        }

        public Student() { }
        public Student(
            string? surname = null,
            string? name = null,
            string? patronymic = null,
            uint? age = null,
            List<string>? nicknames = null,
            float? rating = null,
            uint? universityID = null
        ) : base(surname, name, patronymic, age, nicknames)
        {
            if (rating is not null) Rating = (float)rating;
            if (universityID is not null) UniversityID = (uint)universityID;
        }

        public Person ToPerson() => new(
            Surname,
            Name,
            Patronymic,
            Age,
            Nicknames is not null
                ? new(Nicknames)
                : null
        );

        public override int GetHashCode()
            => (FullName, Age, Nicknames, Rating, UniversityID).GetHashCode();

        public override string ToString() => GetString();

        public new string GetString()
            => $"Student#{GetHashCode()}(surname: {Surname}, name: {Name}, "
            + $"patronymic: {Patronymic}, age: {Age}, "
            + $"nicknames: {(Nicknames == null ? "null" : $"[{string.Join(", ", Nicknames.Select(e => $"\"{e}\""))}]")}, "
            + $"rating: {Rating}, universityID: {UniversityID})";

        public override void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public new void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Student)obj);
        }

        public bool Equals(Student? other)
        {
            if (other is null) return false;

            return FullName.Equals(other.FullName)
                && Age.Equals(other.Age)
                && ReferenceEquals(Nicknames, other.Nicknames)
                && Rating.Equals(other.Rating)
                && UniversityID.Equals(other.UniversityID);
        }

        public override Student ShallowCopy() => (Student)MemberwiseClone();

        public override object Clone() => new Student(
            Surname,
            Name,
            Patronymic,
            Age,
            Nicknames is not null
                ? new(Nicknames)
                : null,
            Rating,
            UniversityID
        );

        public override void Init()
        {
            base.Init();
            Rating = ConsoleIO.Input<float>(
                "Введите рейтинг (0,0 <= значение <= 5,0): ",
                v => v >= 0 && v <= 5
                    ? null
                    : "Недопустимое значение!"
            );
            UniversityID = ConsoleIO.Input<uint>(
                "Введите идентификатор университета (число > 0): ",
                v => v > 0
                    ? null
                    : "Недопустимое значение!"
            );
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Rating = RandomData.GetRating();
            UniversityID = RandomData.GetID();
        }
    }
}