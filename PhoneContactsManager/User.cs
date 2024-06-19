namespace PhoneContactsManager
{
    internal class User
    {
        private readonly List<Contact> contacts = [];

        private static void DisplayContacts(List<Contact> contacts)
        {
            int contactsCounter = 0;

            foreach (Contact contact in contacts)
            {
                contactsCounter++;
                Console.WriteLine(contactsCounter + ")");
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Phone number: {contact.PhoneNumber}\n");
            }
        }

        public Contact? GetContactByPhoneNumber(string phoneNumber) => contacts.FirstOrDefault(e => e.PhoneNumber == phoneNumber);

        public bool AddContact(Contact contact)
        {
            if(GetContactByPhoneNumber(contact.PhoneNumber) == null)
            {
                contacts.Add(contact);
                Console.WriteLine("Successfully added a contact\n");
                return true;
            }
            else
            {
                Console.WriteLine("Contact with the entered phone number already exists\n");
                return false;
            }
        }

        public bool SearchContactsByName(string name)
        {
            List<Contact> foundContacts = contacts.Where(e => e.Name.ToLower().Contains(name.ToLower())).ToList();
            if (foundContacts.Count > 0)
            {
                DisplayContacts(foundContacts);
                return true;
            }
            else
            {
                Console.WriteLine("No contacts found\n");
                return false;
            }
        }

        public bool DeleteContactByPhoneNumber(string phoneNumber)
        {
            Contact? contactToDelete = GetContactByPhoneNumber(phoneNumber);
            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                Console.WriteLine("Successfully deleted a contact\n");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid phone number\n");
                return false;
            }
        }

        public bool DisplayContacts()
        {
            if (contacts.Count > 0)
            {
                DisplayContacts(contacts);
                return true;
            }
            else
            {
                Console.WriteLine("You do not have any contacts\n");
                return false;
            }
        }
    }
}
