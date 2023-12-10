namespace Lab10
{
    public static partial class Program
    {
        private static void Task1Process()
        {
            var isRandomRaw = ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandomRaw is not bool isRandom)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            var array = CreatePersonArray(isRandom);

            ConsoleIO.WriteLine(Messages.VirtualShow);
            for (int index = 0; index < array.Length; index++)
                array[index].VirtualShow();

            ConsoleIO.WriteLine(Messages.Show);
            for (int index = 0; index < array.Length; index++)
                array[index].Show();
        }

        private static void Task2Option1Process()
        {
            var isRandomRaw = ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandomRaw is not bool isRandom)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            var persons = CreatePersonArray(isRandom);
            PrintPersonArray(Messages.Persons, persons);

            var students = Requests.GetStudents(persons);
            PrintPersonArray(Messages.Students, students);
        }

        private static void Task2Option2Process()
        {
            var isRandomRaw = ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandomRaw is not bool isRandom)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            var persons = CreatePersonArray(isRandom);
            PrintPersonArray(Messages.Persons, persons);

            var rating = ConsoleIO.Input<float>(
                Messages.InputRating,
                v => v < 0 || v > 5 ? Messages.InputRatingValidatorError : null
            );

            var students = Requests.GetStudentWithGreaterOrEqualRating(rating, persons);
            PrintPersonArray(Messages.Students, students);
        }

        private static void Task2Option3Process()
        {
            var isRandomRaw = ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandomRaw is not bool isRandom)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            var persons = CreatePersonArray(isRandom);
            PrintPersonArray(Messages.Persons, persons);

            var count = Requests.GetPupilsCount(persons);
            ConsoleIO.WriteLineFormat(Messages.PupilsCount, count);
        }

        private static void Task3Option1Process()
        {
            var isRandomRaw = ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandomRaw is not bool isRandom)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            var persons = CreatePersonArray(isRandom);
            PrintPersonArray(Messages.PersonsBeforeSort, persons);
            Array.Sort(persons);
            PrintPersonArray(Messages.PersonsAfterSortByName, persons);
            Array.Sort(persons, new PersonComparer());
            PrintPersonArray(Messages.PersonsAfterSortByAge, persons);
        }

        private static void Task3Option2Process()
        {
            var isRandomRaw = ConsoleDialog.ShowDialog(ChoiceInputMethodDialog());
            if (isRandomRaw is not bool isRandom)
            {
                ConsoleIO.WriteLine(Messages.ChoiceInputMethodDialogCancel);
                return;
            }
            var persons = CreatePersonArray(isRandom);
            PrintPersonArray(Messages.Persons, persons);

            ConsoleIO.WriteLine(Messages.SearchInputPersonData);
            var person = new Person();
            person.Init();

            var index = Array.BinarySearch(persons, person);
            ConsoleIO.WriteLineFormat(
                index < 0
                    ? Messages.SearchPersonNotFound
                    : Messages.SearchPersonFound,
                index + 1
            );
        }

        private static void Task3Option3Process()
        {
            var array = new IInit[]{
                new SomeClass(),
                new Person(),
                new Student(),
                new PartTimeStudent(),
                new Pupil()
            };

            array[0].Init();
            for (int index = 1; index < array.Length; index++)
                array[index].RandomInit();

            ConsoleIO.WriteLine(Messages.Task3Option3Process);
            foreach (var item in array)
                ConsoleIO.WriteLine(item);
        }

        public static void Task3Option4Process()
        {
            var p1 = new Person("Михаил", 21);
            var p2 = new Person("Вячеслав", 22, p1);

            ConsoleIO.WriteLineFormat(Messages.SourceObject, p2);

            var p3 = p2.Clone();
            ConsoleIO.WriteLineFormat(Messages.ClonedObject, p3);
            ConsoleIO.WriteLineFormat(Messages.IsEqual, p3.Equals(p2) ? Messages.Yes : Messages.No);

            var p4 = p2.ShallowCopy();
            ConsoleIO.WriteLineFormat(Messages.CopiedObject, p4);
            ConsoleIO.WriteLineFormat(Messages.IsEqual, p4.Equals(p2) ? Messages.Yes : Messages.No);
        }
    }
}