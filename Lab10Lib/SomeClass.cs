using ConsoleIOLib;

namespace Lab10Lib
{
    public class SomeClass : IInit
    {
        public SomeClass() { }

        public SomeClass(string someProperty)
        {
            SomeProperty = someProperty;
        }

        private string? someProperty;

        public string SomeProperty
        {
            get => someProperty ?? "--";
            set => someProperty = value;
        }

        public override bool Equals(object? obj) =>
            obj is SomeClass someClass
            && someClass.SomeProperty == SomeProperty;

        public override int GetHashCode() =>
            SomeProperty.GetHashCode();

        public override string ToString() =>
            $"SomeClass(someProperty: {SomeProperty})";

        public void Init()
            => SomeProperty = ConsoleIO.InputRaw("Введите какое-то свойство (строка): ");

        public void RandomInit()
            => SomeProperty = RandomContent.GetGroup();

    }
}