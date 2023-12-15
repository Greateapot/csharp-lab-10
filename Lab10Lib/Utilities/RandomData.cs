namespace Lab10Lib.Utilities
{
    public class RandomData
    {
        private static readonly Random random = new((int)DateTimeOffset.Now.ToUnixTimeMilliseconds());

        private static readonly List<string> surnames = new(){
            "Федотов",
            "Хохлов",
            "Громов",
            "Греков",
            "Гаврилов",
            "Самсонов",
            "Родин",
            "Васильев",
            "Ефимов",
            "Попов",
        };

        private static readonly List<string> names = new(){
            "Михаил",
            "Матвей",
            "Ярослав",
            "Николай",
            "Лев",
            "Тихон",
            "Елисей",
            "Игорь",
            "Фёдор",
            "Никита",
        };

        private static readonly List<string> patronymics = new(){
            "Демидович",
            "Андреевич",
            "Михайлович",
            "Ильич",
            "Фёдорович",
            "Александрович",
            "Антонович",
            "Тимурович",
            "Иванович",
            "Егорович",
        };

        private static readonly List<string> nicknames = new(){
            "Громогласный мастер морей",
            "Яростный разграбитель ереси",
            "Стальной разрушитель ереси",
            "Безрассудный освободитель замков",
            "Величавый освободитель кузнь",

            "Величавый покоритель мудрости",
            "Святой изыскатель вершин",
            "Непобедимый изыскатель знаний",
            "Величавый разрушитель мудрости",
            "Величайший покоритель сокровищ",

            "Волшебный владыка знаний",
            "Волшебный мастер морей",
            "Величавый разрушитель башен",
            "Неудержимый изыскатель ада",
            "Легендарный труженник кузнь",

            "Святой труженник гробниц",
            "Святой владыка мудрости",
            "Красноперый мастер вершин",
            "Величайший очиститель глубин",
            "Святой разрушитель чащ",
        };

        public static string GetSurname() => surnames[random.Next() % surnames.Count];
        public static string GetName() => names[random.Next() % names.Count];
        public static string GetPatronymic() => patronymics[random.Next() % patronymics.Count];
        public static uint GetAge() => (uint)(random.Next() % 20 + 18);
        public static List<string> GetNicknames()
        {
            var count = random.Next() % 3;
            List<string> result = new(capacity: count);
            for (int index = 0; index < count; index++)
            {
                string nickname;
                do
                {
                    nickname = nicknames[random.Next() % nicknames.Count];
                } while (result.Contains(nickname));
                result.Add(nickname);
            }
            return result;
        }
        public static float GetRating() => (float)(random.NextDouble() * 5);
        public static uint GetID() => (uint)(random.Next() % 1000 + 1);
        public static string GetSomeData() => $"random-some-data#{random.Next()}";
    }
}
