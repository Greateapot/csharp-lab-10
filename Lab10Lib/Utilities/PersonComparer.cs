using Lab10Lib.Entities;

namespace Lab10Lib.Utilities
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if (x is null) return -1;
            if (y is null) return 1;
            if (ReferenceEquals(y, x)) return 0;
            int c;

            c = x.Age.CompareTo(y.Age);
            if (c != 0) return c;

            c = x.Surname.CompareTo(y.Surname);
            if (c != 0) return c;

            c = x.Name.CompareTo(y.Name);
            if (c != 0) return c;

            c = x.Patronymic.CompareTo(y.Patronymic);
            if (c != 0) return c;

            return 0;
        }
    }
}