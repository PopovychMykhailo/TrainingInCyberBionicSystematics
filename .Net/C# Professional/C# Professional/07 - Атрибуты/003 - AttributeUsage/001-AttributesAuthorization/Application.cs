using System;
using System.Collections.Generic;

namespace AttributesAuthorization
{
    class Application
    {

        public List<User> Users { get; set; }

        private AuthorizationManager _authorizationManager;

        protected Application()
        {
            _authorizationManager = new AuthorizationManager();
            Users = new List<User>();
            Users.Add(new User()
            {
                Email = "test@test.com",
                Password = "qwerty"
            });
        }

        public void Authorize(User user) 
        {
            var (success, errors) = _authorizationManager.Authorize(user);

            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Пользователь успешно авторизовался!");
                Console.ResetColor();
            }
            else
            {
                foreach (var error in errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(error);
                    Console.ResetColor();
                }
            }
        }

        #region SingletonRealization

        private static Application _instance;

        public static Application GetCurrentApplication()
        {
            if (_instance == null)
            {
                _instance = new Application();
            }

            return _instance;
        }

        #endregion
    }
}
