using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CardComTask.BL
{
    public class ValidationHelper
    {
        private const Int32 minimum_password_size = 8;
        private const Int32 minimum_user_name_size = 5;

        public static bool IsEnglish(string msg)
        {
            if (msg == null)
            {
                return false;
            }
            string expression = "^[a-zA-Z\\d\\s\\-\\[\\]!@#$%^&*()_+={}:;,.ֱֲֳִֵֶַָֹּׁׂ`<>?~|\"\\'/\\\\ ]+$";

            Regex re = new Regex(expression);

            return (re.IsMatch(msg));
        }

        public static bool IsValidUserName(string name, bool withMinimum)
        {
            if (name == null)
            {
                return false;
            }
            if (withMinimum && name.Length < minimum_user_name_size)
            {
                return false;
            }
            string expression = "^[a-zA-Z\\d\\s\\-\\[\\]!@#$%^&*()_+={}:;,.ֱֲֳִֵֶַָֹּׁׂ`<>?~|\"\\'/\\\\]+$";

            Regex re = new Regex(expression);

            return (re.IsMatch(name));
        }

        public static bool IsValidLocalCellPhone(string phone)
        {
            if (phone == null)
            {
                return false;
            }
            phone = phone.Replace("-", "");
            string expression1 = @"^(051|054|052|050|055|057|053|058)\d{7}$";
            string expression2 = @"^((\+9725)(0|1|2|3|4|5|7|8))\d{7}$";
            Regex re1 = new Regex(expression1);
            Regex re2 = new Regex(expression2);
            return (re1.IsMatch(phone) || re2.IsMatch(phone));
        }

        public static bool IsValidCellPhone(string phone)
        {
            if (phone == null)
            {
                return false;
            }
            phone = phone.Replace("-", "");
            string expression = @"^(\+?)\d{12}$";
            Regex re = new Regex(expression);
            return (re.IsMatch(phone));
        }

        public static bool IsValidLocalPhone(string phone)
        {
            if (phone == null)
            {
                return false;
            }
            string expression = @"^((02|03|04|08|09)\d{7})$";
            Regex re = new Regex(expression);
            return (re.IsMatch(phone));
        }

        public static bool IsValidPassword(string password)
        {
            if (password == null || password.Length < minimum_password_size)
            {
                return false;
            }
            string expression = @"^(((\d)((?=.*[a-z])(?=.*[!*@#$%^&+=]).*))|(([a-z]|[A-Z])((?=.*[\d])(?=.*[!*@#$%^&+=]).*)))$";
            Regex regex = new Regex(expression);
            return (regex.IsMatch(password));
        }

        public static bool IsOnlyLetters(string input)
        {
            if (input == null)
            {
                return false;
            }
            string expression = @"^([a-z]|[A-Z]|[\u0590-\u05FF])[a-zA-Z\u0590-\u05FF ]+$";
            Regex regex = new Regex(expression);
            return (regex.IsMatch(input));
        }

        public static bool IsOnlyNumbers(string num)
        {
            if (num == null)
            {
                return false;
            }
            string expression = @"^(\d)+$";
            Regex regex = new Regex(expression);
            return (regex.IsMatch(num));
        }

        public static bool IsValidEMail(string mail)
        {
            if (mail == null)
            {
                return false;
            }
            string expression = @"^((\d|[a-z]|[A-Z])+(@)([a-z]|[A-Z])+(\.)([a-z]|[A-Z])+((\.)([a-z]|[A-Z])+)?)$";
            Regex regex = new Regex(expression);
            return (regex.IsMatch(mail));
        }

        public static bool IsBoolean(string bit)
        {
            if (bit == null || bit.Length > 1)
            {
                return false;
            }
            if (!bit.Equals("0") && !bit.Equals("1"))
            {
                return false;
            }
            return true;
        }
    }
}
