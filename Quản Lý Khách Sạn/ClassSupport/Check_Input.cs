using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quản_Lý_Khách_Sạn.ClassSupport
{
    public class Check_Input
    {
        public static bool IsWhiteSpace(string str)
        {
            foreach (char c in str)
            {
                if (char.IsWhiteSpace(c))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Password_Ok(string str)
        {
            Regex regex = new Regex("[!@#$%^&*()_+{}\\[\\]:;<>,.?/~`]");
            Regex numberRegex = new Regex("[0-9]");
            if (str.Length >= 8 && str.Length <= 20 && regex.IsMatch(str) && !IsWhiteSpace(str) && numberRegex.IsMatch(str))
                return true;
            else
                return false;

        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(84|0[35789])[0-9]{8}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public static bool IsValidEmail(string email)
        {
            var emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(email);
        }
    }
}
