using ConsoleIOLib;
using Lab10Lib.Utilities;


namespace Lab10Lib.Entities
{
    public class Pupil : Person, IEquatable<Pupil>
    {
        protected float? rating;
        protected uint? schoolID;

        public float Rating
        {
            get => rating ?? 0;
            set => rating = value >= 0 && value <= 5
                ? value
                : throw new ArgumentException("invalid rating (not in range(0.0, 5.0))");
        }

        public uint SchoolID
        {
            get => schoolID ?? 0;
            set => schoolID = value > 0
                ? value
                : throw new ArgumentException("invalid school id (zero)");
        }

        public Pupil() { }
        public Pupil(
            string? surname = null,
            string? name = null,
            string? patronymic = null,
            uint? age = null,
            List<string>? nicknames = null,
            float? rating = null,
            uint? schoolID = null
        ) : base(surname, name, patronymic, age, nicknames)
        {
            if (rating is not null) Rating = (float)rating;
            if (schoolID is not null) SchoolID = (uint)schoolID;
        }

        public override int GetHashCode()
            => (FullName, Age, Nicknames, Rating, SchoolID).GetHashCode();

        public override string ToString() => GetString();

        public new string GetString()
            => $"Pupil#{GetHashCode()}(surname: {Surname}, name: {Name}, "
            + $"patronymic: {Patronymic}, age: {Age}, "
            + $"nicknames: {(Nicknames == null ? "null" : $"[{string.Join(", ", Nicknames.Select(e => $"\"{e}\""))}]")}, "
            + $"rating: {Rating}, schoolID: {SchoolID})";

        public override void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public new void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Pupil)obj);
        }

        public bool Equals(Pupil? other)
        {
            if (other is null) return false;

            return FullName.Equals(other.FullName)
                && Age.Equals(other.Age)
                && ReferenceEquals(Nicknames, other.Nicknames)
                && Rating.Equals(other.Rating)
                && SchoolID.Equals(other.SchoolID);
        }

        public override Pupil ShallowCopy() => (Pupil)MemberwiseClone();

        public override object Clone() => new Pupil(
            Surname,
            Name,
            Patronymic,
            Age,
            Nicknames is not null
                ? new(Nicknames)
                : null,
            Rating,
            SchoolID
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
            SchoolID = ConsoleIO.Input<uint>(
                "Введите идентификатор школы (число > 0): ",
                v => v > 0
                    ? null
                    : "Недопустимое значение!"
            );
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Rating = RandomData.GetRating();
            SchoolID = RandomData.GetID();
        }
    }
}