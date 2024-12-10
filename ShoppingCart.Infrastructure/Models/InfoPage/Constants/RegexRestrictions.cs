namespace ShoppingCart.Infrastructure
{
    public static class RegexRestrictions
    {
        public const string ErrorMessage = "";

        public const string FirstName = @"^[^\/!@#\$%\^&\*_\(\)\+=\[\]\\;\{\}\|:<>\?\x22]+$";
        public const string LastName = @"^[^\/!@#\$%\^&\*_\(\)\+=\[\]\\;\{\}\|:<>\?\x22]+$";
        public const string Email = @"^[\w-\+\']+(\.[\w-\+\']+)*@[A-Za-z0-9]([A-Za-z0-9]|[-.][A-Za-z0-9])*\.((?!ru$|by$)[A-Za-z]{2,})$";
        public const string Company = @"^(?!(\s*['.,\/&@()\-#!+]))[^\\\[\]\{\}\|`<>_\$;:~%\*\^_=\x22]+$";
        public const string Phone = @"^[a-zA-Z0-9#()\-\+\.\/\*\,\s]*$";
        public const string Address = @"^[^\[\]\{\}\|`<>@_\$;~%\*\^_=\x22]+$";
        public const string City = @"^[^\[\]\{\}\|`<>@_\$;~%\*\^_=\x22]+$";
        public const string ZipOrPostalCode = @"^[^\/!@#\$%\^&\*_\(\)\+=\[\]\\;\{\}\|:<>\?\x22]+$";
    }
}
