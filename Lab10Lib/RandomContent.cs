namespace Lab10Lib
{
    public class RandomContent
    {
        private static readonly Random random = new(DateTimeOffset.Now.Millisecond);

        private static readonly string[] groups = {
            "РИС",
            "МАК",
            "РОК",
            "ЛУК",
            "ВУД",
        };

        private static readonly string[] names = {
            "Иван",
            "Илья",
            "Андрей",
            "Кирилл",
            "Егор",
        };

        public static string GetName()
            => names[random.Next() % names.Length];

        public static int GetAge()
            => random.Next() % 8 + 18;

        public static bool GetBool()
            => random.Next() % 2 == 1;

        public static int GetGrade()
            => random.Next() % 11 + 1;

        public static float GetRating()
            => (float)(random.Next() % 5 + random.NextDouble());

        public static string GetGroup(bool isPartTime = false, bool isShortenedProgram = false)
            => $"{groups[random.Next() % groups.Length]}-{random.Next() % 30}-{random.Next() % 4 + 1}Б"
            + $"{(isPartTime ? "З" : "")}{(isShortenedProgram ? "У" : "")}";

        public static int GetCourse()
            => random.Next() % 6 + 1;
    }
}