using ConsoleDialogLib;
using ConsoleIOLib;
using Lab10Lib;

namespace Lab10
{
    public class Program
    {
        private static readonly Random random = new(DateTimeOffset.Now.Millisecond);

        public static void Main() => ConsoleDialog.ShowDialog(MainDialog());

        private static ConsoleDialog MainDialog() => new(
            Messages.MainMenuWelcomeText,
            new() {
                new(
                    Messages.MainMenuOption1,
                    _ => Task1Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.MainMenuOption2,
                    _ => ConsoleDialog.ShowDialog(Task2Dialog())
                ),
                new(
                    Messages.MainMenuOption3,
                    _ => ConsoleDialog.ShowDialog(Task3Dialog())
                )
            }
        );

        private static ConsoleDialog Task2Dialog() => new(
            Messages.Task2WelcomeText,
            new() {
                new(
                    Messages.Task2Option1,
                    _ => Task2Option1Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task2Option2,
                    _ => Task2Option2Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task2Option3,
                    _ => Task2Option3Process(),
                    pauseAfterExecuted: true
                )
            }
        );

        private static ConsoleDialog Task3Dialog() => new(
            Messages.Task3WelcomeText,
            new() {
                new(
                    Messages.Task3Option1,
                    _ => Task3Option1Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task3Option2,
                    _ => Task3Option2Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task3Option3,
                    _ => Task3Option3Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task3Option4,
                    _ => Task3Option4Process(),
                    pauseAfterExecuted: true
                )
            }
        );

        private static void Task1Process()
        {
            var array = CreatePersonArray();

            ConsoleIO.WriteLine(Messages.VirtualShow);
            for (int index = 0; index < array.Length; index++)
                array[index].VirtualShow();

            ConsoleIO.WriteLine(Messages.Show);
            for (int index = 0; index < array.Length; index++)
                array[index].Show();
        }

        private static void Task2Option1Process()
        {
            var persons = CreatePersonArray();
            PrintPersonArray(Messages.Persons, persons);

            var students = Requests.GetStudents(persons);
            PrintPersonArray(Messages.Students, students);
        }

        private static void Task2Option2Process()
        {
            var persons = CreatePersonArray();
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
            var persons = CreatePersonArray();
            PrintPersonArray(Messages.Persons, persons);

            var count = Requests.GetPupilsCount(persons);
            ConsoleIO.WriteLineFormat(Messages.PupilsCount, count);
        }

        private static void Task3Option1Process()
        {
            var persons = CreatePersonArray();
            PrintPersonArray(Messages.PersonsBeforeSort, persons);
            Array.Sort(persons);
            PrintPersonArray(Messages.PersonsAfterSortByName, persons);
            Array.Sort(persons, new PersonComparer());
            PrintPersonArray(Messages.PersonsAfterSortByAge, persons);
        }

        private static void Task3Option2Process()
        {
            var persons = CreatePersonArray();
            PrintPersonArray(Messages.Persons, persons);

            ConsoleIO.WriteLine(Messages.SearchInputPersonData);
            var person = new Person();
            person.Init();

            var index = Array.BinarySearch(persons, person);
            if (index < 0)
            {
                ConsoleIO.WriteLine(Messages.SearchPersonNotFound);
            }
            else
            {
                ConsoleIO.WriteLineFormat(Messages.SearchPersonFound, index + 1);
            }
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

        private static void PrintPersonArray(string? message = null, params Person[] persons)
        {
            ConsoleIO.WriteLine(message);
            foreach (var person in persons)
                ConsoleIO.WriteLine(person);
        }

        private static Person[] CreatePersonArray()
        {
            uint length = ConsoleIO.Input<uint>(Messages.InputLength);
            var array = new Person[length];
            for (int index = 0; index < length; index++)
                switch (random.Next() % 4)
                {
                    case 0:
                        var person = new Person();
                        person.RandomInit();
                        array[index] = person;
                        break;
                    case 1:
                        var pupil = new Pupil();
                        pupil.RandomInit();
                        array[index] = pupil;
                        break;
                    case 2:
                        var student = new Student();
                        student.RandomInit();
                        array[index] = student;
                        break;
                    case 3:
                        var partTimeStudent = new PartTimeStudent();
                        partTimeStudent.RandomInit();
                        array[index] = partTimeStudent;
                        break;
                }
            return array;
        }
    }
}