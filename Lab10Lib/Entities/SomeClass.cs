using ConsoleIOLib;
using Lab10Lib.Interfaces;
using Lab10Lib.Utilities;


namespace Lab10Lib.Entities
{
    public class SomeClass : IInit, IEquatable<SomeClass>, IStringable, ICloneable
    {
        protected string? someProperty;
        public string SomeProperty
        {
            get => someProperty ?? "--";
            set => someProperty = value;
        }

        public SomeClass() { }
        public SomeClass(dynamic? someProperty = null)
        {
            if (someProperty is not null) SomeProperty = someProperty;
        }

        public override int GetHashCode() => SomeProperty.GetHashCode();

        public override string ToString() => GetString();

        public string GetString()
            => $"SomeClass#{GetHashCode()}(someProperty: {SomeProperty})";

        public virtual void VirtualShow() => ConsoleIO.WriteLine(GetString());

        public void Show() => ConsoleIO.WriteLine(GetString());

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((SomeClass)obj);
        }

        public bool Equals(SomeClass? other)
        {
            if (other is null) return false;

            return SomeProperty.Equals(other.SomeProperty);
        }

        public SomeClass ShallowCopy() => (SomeClass)MemberwiseClone();

        public object Clone() => new SomeClass(SomeProperty);

        public void Init()
            => SomeProperty = ConsoleIO.InputRaw("Введите какое-то свойство (строка): ");

        public void RandomInit()
            => SomeProperty = RandomData.GetSomeData();
    }
}