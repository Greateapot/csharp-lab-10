using ConsoleIOLib;
using Lab10Lib.Interfaces;
using Lab10Lib.Utilities;

namespace Lab10Lib.Entities
{
    public class Person : IInit, ICloneable, IEquatable<Person>, IComparable<Person>, IStringable
    {
        protected string? name;
        protected string? surname;
        protected string? patronymic;
        protected uint? age;
        protected List<string>? nicknames;

        public string Name
        {
            get => name ?? "--";
            set => name = value.Length > 0
                ? value
                : throw new ArgumentException("invalid name (zero length)");
        }

        public string Surname
        {
            get => surname ?? "--";
            set => surname = value.Length > 0
                ? value
                : throw new ArgumentException("invalid surname (zero length)");
        }

        public string Patronymic
        {
            get => patronymic ?? "--";
            set => patronymic = value.Length > 0
                ? value
                : throw new ArgumentException("invalid patronymic (zero length)");
        }

        public uint Age
        {
            get => age ?? 0;
            set => age = value > 0 && value < 100
                ? value
                : throw new ArgumentException("invalid age (not in range(1,100))");
        }

        public string FullName => $"{Surname} {Name} {Patronymic}";

        public List<string>? Nicknames { get; set; }

        public Person() { }

        public Person(
            string? surname = null,
            string? name = null,
            string? patronymic = null,
            uint? age = null,
            List<string>? nicknames = null
        )
        {
            if (surname is not null) Surname = surname;
            if (name is not null) Name = name;
            if (patronymic is not null) Patronymic = patronymic;
            if (age is not null) Age = (uint)age; // lol
            if (nicknames is not null) Nicknames = nicknames;
        }

        public override int GetHashCode()
            => (FullName, Age, Nicknames).GetHashCode();

        public override string ToString() => GetString();

        public string GetString()
            => $"Person#{GetHashCode()}(surname: {Surname}, name: {Name}, "
            + $"patronymic: {Patronymic}, age: {Age}, "
            + $"nicknames: {(Nicknames == null ? "null" : $"[{string.Join(", ", Nicknames.Select(e => $"\"{e}\""))}]")})";

        public virtual void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Person)obj);
        }

        public virtual Person ShallowCopy() => (Person)MemberwiseClone();

        public virtual object Clone() => new Person(
            Surname,
            Name,
            Patronymic,
            Age,
            Nicknames is not null
                ? new(Nicknames)
                : null
        );

        public int CompareTo(Person? other)
        {
            if (other is null) return 1;
            if (ReferenceEquals(other, this)) return 0;

            int c;

            c = Surname.CompareTo(other.Surname);
            if (c != 0) return c;

            c = Name.CompareTo(other.Name);
            if (c != 0) return c;

            c = Patronymic.CompareTo(other.Patronymic);
            if (c != 0) return c;

            c = Age.CompareTo(other.Age);
            if (c != 0) return c;

            return 0;
        }

        public bool Equals(Person? other)
        {
            if (other is null) return false;
            return FullName.Equals(other.FullName)
                && Age.Equals(other.Age)
                && ReferenceEquals(Nicknames, other.Nicknames);
        }

        public virtual void Init()
        {
            Surname = ConsoleIO.InputRaw("Введите фамилию: ");
            Name = ConsoleIO.InputRaw("Введите имя: ");
            Patronymic = ConsoleIO.InputRaw("Введите отчество: ");
            Age = ConsoleIO.Input<uint>(
                "Введите возраст (0 < значение < 100): ",
                v => v > 0 && v < 100
                    ? null
                    : "Недопустимое значение!"
            );

            var count = ConsoleIO.Input<uint>("Введите кол-во псевдонимов: ");
            Nicknames = new();
            if (count > 0)
                for (int index = 0; index < count; index++)
                    Nicknames.Add(ConsoleIO.InputRaw($"Введите псевдоним №{index + 1}: "));
        }

        public virtual void RandomInit()
        {
            Surname = RandomData.GetSurname();
            Name = RandomData.GetName();
            Patronymic = RandomData.GetPatronymic();
            Age = RandomData.GetAge();
            Nicknames = RandomData.GetNicknames();
        }
    }
}