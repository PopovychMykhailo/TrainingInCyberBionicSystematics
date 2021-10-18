using System;

namespace _007_Operators
{
    sealed class PhoneNumber
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            Value = IsValidPhoneNumber(value)
                ? value
                : throw new ArgumentException($"\"{value}\" is not a valid phone", nameof(value));
        }

        public static implicit operator string(PhoneNumber phoneNumber)
        {
            return phoneNumber.Value;
        }

        public static explicit operator PhoneNumber(string phoneNumber)
        {
            return IsValidPhoneNumber(phoneNumber)
                ? new PhoneNumber(phoneNumber)
                : throw new InvalidCastException($"Cannot cast string \"{phoneNumber}\" to {nameof(PhoneNumber)}; Not a valid phone number");
        }

        private static bool IsValidPhoneNumber(string value)
        {
            bool AllCharsAreDigits(string str) 
            {
                foreach (var @char in str.ToCharArray())
                {
                    if (!char.IsDigit(@char))
                    {
                        return false;
                    }
                }
                return true;
            }

            return value.Length == 13 
                && value.StartsWith("+38") 
                && AllCharsAreDigits(value.Substring(1));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is PhoneNumber other 
                ? other.Value == this.Value 
                : false;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    class Email { } 

    class Program
    {
        static void Main(string[] args)
        {
            var phone = "+380901233445";
            Console.WriteLine(phone);

            string strPhone = phone;
            Console.WriteLine(strPhone);

            string email = "test@mail.com";

            phone = email;

            PhoneNumber phone1 = (PhoneNumber)"test@mail.com";

        }
    }
}
