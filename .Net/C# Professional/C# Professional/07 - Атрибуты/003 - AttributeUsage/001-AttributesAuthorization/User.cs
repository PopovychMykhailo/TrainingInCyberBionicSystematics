namespace AttributesAuthorization
{
    class User
    {
        [RegexPattern(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Пожалуйста, введите действительый email")]
        public string Email { get; set; }

        [RegexPattern(@"^[^ ]{6,18}$", ErrorMessage = "Пароль должен содержать от 6 до 18 символов")]
        public string Password { get; set; }
    }
}
