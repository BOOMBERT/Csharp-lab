namespace PhoneContactsManager
{
    internal class Contact
    {
        private string phoneNumber = "000000000";
        public const int PhoneNumberLength = 9;

        public string Name { get; set; }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == PhoneNumberLength)
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Invalid phone number");
                }
            }
        }

        public Contact(string name, string phoneNumber) 
        { 
            Name = name.ToUpper();
            PhoneNumber = phoneNumber.ToUpper();
        }
    }
}
