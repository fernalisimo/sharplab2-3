using System;
using System.Text.RegularExpressions;
using Lab3.Exceptions;


namespace Lab3
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAdult { get; }
        public string Western { get; }
        public string Chinese { get; }
        public bool IsBirthday { get; }

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;

            if (!EmailValid(email)) throw new Email("Please enter normalniy email");
            Email = email;

            if (Age(dateOfBirth) > 135) throw new Old("U are too old to use PC, aren't u?");
            if (Age(dateOfBirth) < 0) throw new Birth("It seems me you don't rodilsya yet!");
            DateOfBirth = dateOfBirth;

            IsAdult = Age(dateOfBirth) > 18;
            Western = WesternZodiac();
            Chinese = ChineseZodiac();
            IsBirthday = BirthdayCheck();
        }


        private string ChineseZodiac()
        {
            switch (DateOfBirth.Year % 12)
            {
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Monkey";
            }
        }
        private string WesternZodiac()
        {
            if ((DateOfBirth.Month == 3 && DateOfBirth.Day >= 21) || (DateOfBirth.Month == 4 && DateOfBirth.Day <= 20))
                return "Aries";
            if ((DateOfBirth.Month == 4 && DateOfBirth.Day >= 21) || (DateOfBirth.Month == 5 && DateOfBirth.Day <= 20))
                return "Taurus";
            if ((DateOfBirth.Month == 5 && DateOfBirth.Day >= 21) || (DateOfBirth.Month == 6 && DateOfBirth.Day <= 21))
                return "Gemini";
            if ((DateOfBirth.Month == 6 && DateOfBirth.Day >= 22) || (DateOfBirth.Month == 7 && DateOfBirth.Day <= 22))
                return "Cancer";
            if ((DateOfBirth.Month == 7 && DateOfBirth.Day >= 23) || (DateOfBirth.Month == 8 && DateOfBirth.Day <= 23))
                return "Leo";
            if ((DateOfBirth.Month == 8 && DateOfBirth.Day >= 24) || (DateOfBirth.Month == 9 && DateOfBirth.Day <= 23))
                return "Virgo";
            if ((DateOfBirth.Month == 9 && DateOfBirth.Day >= 24) || (DateOfBirth.Month == 10 && DateOfBirth.Day <= 22))
                return "Libra";
            if ((DateOfBirth.Month == 10 && DateOfBirth.Day >= 23) || (DateOfBirth.Month == 11 && DateOfBirth.Day <= 22))
                return "Scorpio";
            if ((DateOfBirth.Month == 11 && DateOfBirth.Day >= 23) || (DateOfBirth.Month == 12 && DateOfBirth.Day <= 21))
                return "Sagittarius";
            if ((DateOfBirth.Month == 12 && DateOfBirth.Day >= 22) || (DateOfBirth.Month == 1 && DateOfBirth.Day <= 20))
                return "Capricorn";
            if ((DateOfBirth.Month == 1 && DateOfBirth.Day >= 21) || (DateOfBirth.Month == 2 && DateOfBirth.Day <= 19))
                return "Aquarius";
            return "Pisces";
        }
        private int Age(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Today;

            int age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
                age--;

            return age;
        }
        private bool BirthdayCheck()
        {
            return DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day == DateTime.Today.Day;
        }

        private bool EmailValid(string email)
        {
            Regex validEmailRegex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
+ "@"
+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", RegexOptions.IgnoreCase);
            return validEmailRegex.IsMatch(email);

        }
    }
}
