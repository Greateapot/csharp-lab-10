namespace Lab10
{
    public static class Requests
    {
        public static Person[] GetStudents(params Person[] persons)
        {
            Person[] array;
            {
                var length = 0;
                foreach (var person in persons)
                    if (person is Student) length++;
                array = new Person[length];
            }
            {
                var index = 0;
                foreach (var person in persons)
                    if (person is Student) array[index++] = person;
            }
            return array;
        }

        public static Person[] GetStudentWithGreaterOrEqualRating(float rating, params Person[] persons)
        {
            Person[] array;
            {
                var length = 0;
                foreach (var person in persons)
                    if (person is Student student && student.Rating >= rating)
                        length++;
                array = new Person[length];
            }
            {
                var index = 0;
                foreach (var person in persons)
                    if (person is Student student && student.Rating >= rating)
                        array[index++] = person;
            }
            return array;
        }

        public static Person? GetStudentWithHigherRating(params Person[] persons)
        {
            var rating = 0f;
            Person? result = null;

            foreach (var person in persons)
                if (person is Student student && student.Rating > rating)
                {
                    rating = student.Rating;
                    result = student;
                }

            return result;
        }

        public static int GetPupilsCount(params Person[] persons)
        {
            int count = 0;
            foreach (var person in persons)
                if (person is Pupil) count++;
            return count;
        }
    }
}