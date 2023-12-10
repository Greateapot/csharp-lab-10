namespace Lab10Lib
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y) => (x is null || y is null)
            ? throw new ArgumentException("Unnable to compare with null value.")
            : x.Age.CompareTo(y.Age);
    }
}