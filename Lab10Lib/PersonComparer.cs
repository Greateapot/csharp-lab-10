namespace Lab10Lib
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if ((x is Person px) && (y is Person py))
            {
                return px.Age.CompareTo(py.Age);
            }
            else
            {
                throw new ArgumentException("obj is not Person");
            }
        }
    }
}