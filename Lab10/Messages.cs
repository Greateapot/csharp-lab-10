namespace Lab10
{
    public static class Messages
    {
        public const string MainMenuWelcomeText = "Выберите задание: ";
        public const string MainMenuOption1 = "Задание 1";
        public const string MainMenuOption2 = "Задание 2";
        public const string MainMenuOption3 = "Задание 3";
        public const string Task2WelcomeText = "Выберите запрос: ";
        public const string Task2Option1 = "Выбрать студентов из списка персон";
        public const string Task2Option2 = "Выбрать студентов из списка персон, у которых рейтинг больше или равен заданному";
        public const string Task2Option3 = "Посчитать кол-во школьников";
        public const string Task3WelcomeText = "Выберите подзадание: ";
        public const string Task3Option1 = "Сортировка";
        public const string Task3Option2 = "Бинарный поиск";
        public const string Task3Option3 = "Демонстрация работы Init/RandomInit";
        public const string Task3Option4 = "Клонирование/Поверхностное копирование";
        public const string VirtualShow = "\nВывод персон (виртуальный метод): ";
        public const string Show = "\nВывод персон (НЕ виртуальный метод): ";
        public const string Persons = "\nПерсоны: ";
        public const string Students = "\nСтуденты: ";
        public const string PupilsCount = "\nКол-во школьников: {0}";
        public const string PersonsBeforeSort = "\nПерсоны до сортировки: ";
        public const string PersonsAfterSortByName = "\nПерсоны после сортировки по имени (Icomparable): ";
        public const string PersonsAfterSortByAge = "\nПерсоны после сортировки по возрасту (IComparer): ";
        public const string Task3Option3Process = "\nМассив элементов типа IInit (первый введен вручную (Init), остальные рандомно (RandomInit, там вводить много)): ";
        public const string IsEqual = "Эквивалентен ли новый объект копируемому объекту: {0}";
        public const string Yes = "Да";
        public const string No = "Нет";
        public const string SourceObject = "\nИсходный объект: {0}";
        public const string ClonedObject = "\nСклонированный объект: {0}";
        public const string CopiedObject = "\nПоверхностно скопированный объект: {0}";
        public const string InputLength = "Введите длину: ";
        public const string SearchInputPersonData = "\nВведите данные искомой персоны: ";
        public const string SearchPersonNotFound = "\nПерсона с заданными критериями не найдена.";
        public const string SearchPersonFound = "\nНомер персоны с заданными критериями в списке: {0}";
        public const string InputRating = "Введите рейтинг (0,0 <= R <= 5,0): ";
        public const string InputRatingValidatorError = "Введен некорректный рейтинг.";
        public const string ChoiceInputMethodDialogWelcomeText = "Выберите метод ввода массива:";
        public const string ChoiceInputMethodDialogManual = "Вручную";
        public const string ChoiceInputMethodDialogRandom = "Случайно";
        public const string ChoiceInputMethodDialogCancel = "Отмена";
        public const string ChoicePersonType = "Выберите тип персоны:"
            + "\n1. Персона (Person)"
            + "\n2. Ученик (Pupil)"
            + "\n3. Студент (Student)"
            + "\n4. Студент-заочник (PartTimeStudent)"
            + "\nВвод: ";
    }
}