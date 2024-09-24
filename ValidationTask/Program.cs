using System.Net.Http.Headers;

namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, username, password, emailAddress;
            int age;

            // get the user inputs until all are valid.
            // The username should only be output once
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            while (!ValidName(firstName))
            {
                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();
            }
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
            while (!ValidName(lastName))
            {
                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
            }
            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());
            while (!validAge(age))
            {
                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
            while (!ValidPassword(password))
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
            }
            Console.Write("Enter email address: ");
            emailAddress = Console.ReadLine();
            while (!validEmail(emailAddress))
            {
                Console.Write("Enter email address: ");
                emailAddress = Console.ReadLine();
            }


            username = createUserName(firstName,lastName,age);
            Console.WriteLine($"Username is {username}, you have successfully registered please remember your password");

            //  Test your program with a range of tests to show all validation works
            // Show your evidence in the Readme

        }
        static bool ValidName(string name)
        {
            // name must be at least two characters and contain only letters
            if (name.Length >= 2)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    int ascii = Convert.ToByte(name[i]);
                    if (ascii > 122 || ascii < 65 || (ascii > 90 && ascii < 97))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        

        static bool validAge(int age)
        {
            //age must be between 11 and 18 inclusive
            if (age >= 11 && age <= 18)
            {
                return true;
            }
            return false;
        }


        static bool ValidPassword(string password)
        {
            // Check password is at least 8 characters in length
            if (password.Length < 8)
            {
                return false;
            }

            // Check password contains a mix of lower case, upper case and non letter characters
            // QWErty%^& = valid
            // QWERTYUi = not valid
            // ab£$%^&* = not valid
            // QWERTYu! = valid
            int upper = 0;
            int lower = 0;
            int nonLetter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                int ascii = Convert.ToByte(password[i]);
                if (ascii >= 65 && ascii <= 90)
                {
                    upper++;
                }
                else if (ascii >= 97 && ascii <= 122)
                {
                    lower++;
                }
                else
                {
                    nonLetter++;
                }

            }
            if (upper == 0 || lower == 0 || nonLetter == 0)
            {
                return false;
            }

            // Check password contains no runs of more than 2 consecutive or repeating letters or numbers
            // AAbbdd!2 = valid (only 2 consecutive letters A and B and only 2 repeating of each)
            // abC461*+ = not valid (abC are 3 consecutive letters)
            // 987poiq! = not valid (987 are consecutive)
            for (int i = 0; i < password.Length-2; i++)
            {
                if (password[i] == password[i + 1] && password[i + 1] == password[i + 2])
                {
                    return false;
                }
                if (password[i] + 1 == password[i + 1] && password[i + 1] + 1 == password[i + 2])
                {
                    return false;
                }
            }
            return true;

        }
        static bool validEmail(string email)
        {
            // a valid email address
            // has at least 2 characters followed by an @ symbol
            if (email.IndexOf('@') <= 1)
            {
                return false;
            }
            // has at least 2 characters followed by a .
            if (email.IndexOf('.') < 2)
            {
                return false;
            }
            // has at least 2 characters after the .
            int count = 0;
            for (int i = email.IndexOf('.'); i <= email.Length; i++)
            {
                count++;
            }
            if (count < 2)
            {
                return false;
            }
            // contains only one @ and any number of .
            count = 0;
            for (int i = 0; i < email.Length; i++)
            {
                int ascii = Convert.ToByte(email[i]);
                if (ascii == 64)  //64 is the ASCII code of '@'
                {
                    count++;
                }
            }
            if (count > 1)
            {
                return false;
            }
            // does not contain any other non letter or number characters
            for (int i = 0; i < email.Length; i++)
            {
                int ascii = Convert.ToByte(email[i]);
                if ((ascii >= 48 && ascii <= 57) || ascii > 122 || ascii < 65 || (ascii > 90 && ascii < 97))
                {
                    if (ascii != 64 && ascii != 46)
                    {
                        return false;
                    }
                }
            }
            return true;

        }
        static string createUserName(string firstName, string lastName, int age)
        {
            // username is made up from:
            // first two characters of first name
            // last two characters of last name
            // age
            //e.g. Bob Smith aged 34 would have the username Both34

            string userName = firstName.Substring(0, 2) + lastName.Substring(lastName.Length - 2, lastName.Length - 1) + age;
            return userName;

        }

    }
}
