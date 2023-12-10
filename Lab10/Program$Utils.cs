namespace Lab10
{
    public static partial class Program
    {
        private static readonly Random random = new(DateTimeOffset.Now.Millisecond);

        private static void PrintPersonArray(string? message = null, params Person[] persons)
        {
            ConsoleIO.WriteLine(message);
            var formatString = $"{{0,{persons.Length.ToString().Length}}}. {{1}}";
            for (int index = 0; index < persons.Length; index++)
                ConsoleIO.WriteLineFormat(formatString, index + 1, persons[index]);
        }

        private static Person[] CreatePersonArray(bool isRandom = true) => isRandom
            ? CreateRandomPersonArray()
            : CreateManualPersonArray();

        private static Person[] CreateManualPersonArray()
        {
            uint length = ConsoleIO.Input<uint>(Messages.InputLength);
            var array = new Person[length];
            for (int index = 0; index < length; index++)
                switch (ConsoleIO.Input<uint>(
                    Messages.ChoicePersonType,
                    v => v < 1 || v > 4 ? "" : null
                ))
                {
                    case 1:
                        var person = new Person();
                        person.Init();
                        array[index] = person;
                        break;
                    case 2:
                        var pupil = new Pupil();
                        pupil.Init();
                        array[index] = pupil;
                        break;
                    case 3:
                        var student = new Student();
                        student.Init();
                        array[index] = student;
                        break;
                    case 4:
                        var partTimeStudent = new PartTimeStudent();
                        partTimeStudent.Init();
                        array[index] = partTimeStudent;
                        break;
                }
            return array;
        }

        private static Person[] CreateRandomPersonArray()
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