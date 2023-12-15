using ConsoleIOLib;
using Lab10Lib.Utilities;

namespace Lab10Lib.Entities
{
    public class PartTimeStudent : Student, IEquatable<PartTimeStudent>
    {
        protected string? someData; // я не знаю, какое есть св-во у заочника, кт нет у очника.

        public string SomeData
        {
            get => someData ?? "--";
            set => someData = value;
        }

        public PartTimeStudent() { }
        public PartTimeStudent(
            string? surname = null,
            string? name = null,
            string? patronymic = null,
            uint? age = null,
            List<string>? nicknames = null,
            float? rating = null,
            uint? universityID = null,
            string? someData = null
        ) : base(surname, name, patronymic, age, nicknames, rating, universityID)
        {
            if (someData is not null) SomeData = someData;
        }

        public override int GetHashCode()
            => (FullName, Age, Nicknames, Rating, UniversityID, SomeData).GetHashCode();

        public override string ToString() => GetString();

        public new string GetString()
            => $"PartTimeStudent#{GetHashCode()}(surname: {Surname}, name: {Name}, "
            + $"patronymic: {Patronymic}, age: {Age}, "
            + $"nicknames: {(Nicknames == null ? "null" : $"[{string.Join(", ", Nicknames.Select(e => $"\"{e}\""))}]")}, "
            + $"rating: {Rating}, universityID: {UniversityID}, someData: {SomeData})";

        public override void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public new void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((PartTimeStudent)obj);
        }

        public bool Equals(PartTimeStudent? other)
        {
            if (other is null) return false;

            return FullName.Equals(other.FullName)
                && Age.Equals(other.Age)
                && ReferenceEquals(Nicknames, other.Nicknames)
                && Rating.Equals(other.Rating)
                && UniversityID.Equals(other.UniversityID)
                && SomeData.Equals(other.SomeData);
        }

        public override PartTimeStudent ShallowCopy() => (PartTimeStudent)MemberwiseClone();

        public override object Clone() => new PartTimeStudent(
            Surname,
            Name,
            Patronymic,
            Age,
            Nicknames is not null
                ? new(Nicknames)
                : null,
            Rating,
            UniversityID,
            SomeData
        );

        public override void Init()
        {
            base.Init();
            SomeData = ConsoleIO.InputRaw("Введите какие-то доп. данные (строка): ");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            SomeData = RandomData.GetSomeData();
        }
    }
}