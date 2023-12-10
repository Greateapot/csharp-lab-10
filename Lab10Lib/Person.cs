using ConsoleIOLib;

namespace Lab10Lib
{
    public class Person : IInit, IComparable, ICloneable
    {
        public Person() { }

        public Person(
            string name,
            int age,
            Person? bestFriend = null
        )
        {
            Name = name;
            Age = age;
            BestFriend = bestFriend;
        }

        public Person? BestFriend { get; set; }

        private string? name;

        public string Name
        {
            get => name ?? "--";
            set => name = (value.Length == 0)
                ? throw new ArgumentException("Указано невозможное имя")
                : value;
        }

        private int age;

        public int Age
        {
            get => age;
            set => age = (value < 1 || value > 120)
                ? throw new ArgumentException("Указан невозможный возраст")
                : value;
        }

        public virtual void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj) =>
            obj is Person person
            && person.Name == Name
            && person.Age == Age
            && person.BestFriend == BestFriend;

        public override int GetHashCode() =>
            (Name, Age, BestFriend).GetHashCode();

        public string GetString() =>
            $"Person(name: {Name}, age: {Age}, bestFriend: {(BestFriend == null ? "null" : BestFriend)})";

        public override string ToString() => GetString();

        public void Init()
        {
            Name = ConsoleIO.InputRaw("Введите имя: ");
            Age = ConsoleIO.Input<int>(
                "Введите возраст (1 <= A <= 120): ",
                v => v < 1 || v > 120 ? "Указан невозможный возраст" : null
            );
        }

        public void RandomInit()
        {
            Name = RandomContent.GetName();
            Age = RandomContent.GetAge();
        }

        public int CompareTo(object? obj) => (obj is Person person)
            ? Name.CompareTo(person.Name)
            : throw new ArgumentException("Сравниваемый элемент не является классом (или наследником класса) Person");

        public virtual Person ShallowCopy()
            => (Person)MemberwiseClone();

        public virtual object Clone()
            => new Person(
                Name,
                Age,
                BestFriend != null
                    ? new Person(
                        BestFriend.Name,
                        BestFriend.Age
                    )
                    : null
            );
    }
}