using PhoneContactsManager;

static void MainLoop()
{
    Console.WriteLine("Welcome to the phone contacts manager\n");
    bool isRunning = true;
    var user = new User();

    while (isRunning)
    {
        Console.WriteLine(
            "Choose the option:" +
            "\n1 - add a contact" +
            "\n2 - delete a contact" +
            "\n3 - display all contacts" +
            "\n4 - search contacts by name" +
            "\n5 - get contact by phone number" +
            "\n6 - exit\n"
        );
        Console.Write("Enter here: ");
        var inputOption = Console.ReadLine();

        switch (inputOption)
        {
            case "1":
                Console.Write("Enter a contact name: ");
                var contactName = Console.ReadLine();

                Console.Write("Enter a contact phone number: ");
                var contactPhoneNumber = Console.ReadLine();

                if (!string.IsNullOrEmpty(contactName) && !string.IsNullOrEmpty(contactPhoneNumber))
                {
                    try
                    {
                        user.AddContact(new Contact(contactName, contactPhoneNumber));
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine($"Invalid contact data\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid data to create a contact\n");
                }
                break;

            case "2":
                Console.Write("Enter a phone number to delete a contact: ");
                var phoneNumberToDeleteContact = Console.ReadLine();

                if (!string.IsNullOrEmpty(phoneNumberToDeleteContact))
                {
                    user.DeleteContactByPhoneNumber(phoneNumberToDeleteContact);
                }
                else
                {
                    Console.WriteLine("Invalid phone number\n");
                }
                break;

            case "3":
                user.DisplayContacts();
                break;

            case "4":
                Console.Write("Enter a name to search a contacts: ");
                var nameToSearchContacts = Console.ReadLine();

                if (!string.IsNullOrEmpty(nameToSearchContacts))
                {
                    user.SearchContactsByName(nameToSearchContacts);
                }
                else
                {
                    Console.WriteLine("Invalid name to search\n");
                }
                break;

            case "5":
                Console.Write("Enter a phone number to get a contact: ");
                var phoneNumberToGetContact = Console.ReadLine();

                if (!string.IsNullOrEmpty(phoneNumberToGetContact))
                {
                    Contact? contactByPhoneNumber = user.GetContactByPhoneNumber(phoneNumberToGetContact);

                    if (contactByPhoneNumber != null)
                    {
                        Console.WriteLine($"Name: {contactByPhoneNumber.Name}");
                        Console.WriteLine($"Phone number: {contactByPhoneNumber.PhoneNumber}\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid phone number\n");
                }
                break;

            case "6":
                isRunning = false;
                break;

            default:
                Console.WriteLine("Invalid option\n");
                break;
        }
    }
}

MainLoop();
