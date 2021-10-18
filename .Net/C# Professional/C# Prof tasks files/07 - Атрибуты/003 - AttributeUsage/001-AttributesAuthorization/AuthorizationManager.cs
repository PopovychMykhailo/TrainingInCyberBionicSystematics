using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AttributesAuthorization
{
    class AuthorizationManager
    {

        public (bool success, List<string> errors) Authorize(User user)
        {
            Type userType = user.GetType();
            var properties = userType.GetProperties();

            var errors = ValidateUserFields(properties, user);

            if (errors.Count == 0)
            {
                var (success, error) = TryLogin(user);
                if (!success)
                {
                    errors.Add(error);
                }
            }

            return (errors.Count == 0, errors);
        }

        private List<string> ValidateUserFields(IEnumerable<PropertyInfo> properties, User user)
        {
            List<string> errors = new List<string>();
            foreach (var propertyInfo in properties)
            {
                if (HasRegexAttribute(propertyInfo))
                {
                    var (success, error) = ValidateProperty(propertyInfo, user);
                    if (!success) 
                    {
                        errors.Add(error);
                    }
                }
            }
            return errors;
        }

        private (bool success, string errorMessage) TryLogin(User user)
        {
            var isValidUser = Application.GetCurrentApplication().Users
                .Any(u => u.Email == user.Email
                          && u.Password == user.Password);

            if (isValidUser)
            {
                return (true, null);
            }
            else
            {
                return (false, "Введен неверный email или пароль.");
            }
        }

        private bool HasRegexAttribute(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(RegexPatternAttribute), false)
                   .Any();
        }

        private (bool success, string errorMessage) ValidateProperty(PropertyInfo propertyInfo, User user)
        {
            string value = propertyInfo.GetValue(user) as string;

            if (value == null)
            {
                return (true, null);
            }

            var regexAttribute = propertyInfo
                .GetCustomAttributes(typeof(RegexPatternAttribute), false)
                .First() as RegexPatternAttribute;

            Regex regex = new Regex(regexAttribute.Pattern);
            if (!regex.IsMatch(value))
            {
                return (false, regexAttribute.ErrorMessage);
            }
            return (true, null);
        }
    }
}
