// See https://aka.ms/new-console-template for more information
using DocumentWorkflowSystem;
using DocumentWorkflowSystem.Factory;
using System.ComponentModel.Design;
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");


Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
//Store all users and documents
List<User> users = new List<User>();
List<Document> documents = new List<Document>();

GrantProposalFactory grantProposalFactory = new GrantProposalFactory();
TechnicalReportFactory technicalReportFactory = new TechnicalReportFactory();

//Initialise users
User joseph = new User("Joseph");
User yunze = new User("Yun Ze");
User zhenkang = new User("Zhen Kang");
User louis = new User("Louis");

//Adding to users list
users.Add(joseph);
users.Add(yunze);
users.Add(zhenkang);
users.Add(louis);

//Initalise document
Document josephDoc = grantProposalFactory.createDocument(joseph);
Document anotherDoc = grantProposalFactory.createDocument(yunze);
Document nextDoc = technicalReportFactory.createDocument(zhenkang);


//Adding document to User 
joseph.addDocument(josephDoc);
yunze.addDocument(anotherDoc);

//Adding to document List
documents.Add(josephDoc);
documents.Add(anotherDoc);

mainMenu();

//Main menu 
void mainMenu(){
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine();
        Console.WriteLine("===== MENU =====");
        Console.WriteLine("1. Create new user");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. List all users");
        Console.WriteLine("4. List all documents");
        Console.WriteLine("0. Exit");
        Console.Write("Enter your choice: ");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine();
                Console.WriteLine("New user.");
                createUser();
                break;
            case "2":
                Console.WriteLine();
                Console.WriteLine("Login");
                User currentUser = login();
                if (currentUser != null)
                {
                    userMenu(currentUser);
                }
                else
                {
                    Console.WriteLine("Invalid user");
                }
                break;
            case "3":
                Console.WriteLine();
                Console.WriteLine("Listing all Users...");
                foreach(User u in users)
                {
                    Console.WriteLine(u.Name);
                }
                break;
            case "4":
                Console.WriteLine();
                Console.WriteLine("Listing all Documents...");
                foreach (Document doc in documents)
                {
                    Console.WriteLine($"{doc.Title} ({doc.Owner.Name})");
                }
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice! Please enter a number between 1 and 4.");
                break;
        }
    }
}

//Create new Users
void createUser()
{
    Console.Write("Enter name");
    string name = Console.ReadLine();
    User user = new User(name);
    users.Add(user);
}

//Verify User login
User login()
{
    Console.Write("Enter name");
    string name = Console.ReadLine();
    foreach (User u in users)
    {
        if (u.Name == name)
        {
             return u;
        }
    }
    return null;
}

//User menu
void userMenu(User currentUser)
{
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("===== USER MENU =====");
        Console.WriteLine("1. Create new document");
        Console.WriteLine("2. edit document");
        Console.WriteLine("3. List your documents");
        Console.WriteLine("0. Logout");
        Console.Write("Enter your choice: ");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("New document.");
                currentUser.createDocument();
                break;
            case "2":
                Console.WriteLine("Edit document ");
                Document currentDoc = getDoc(currentUser);
                if(currentDoc != null)
                {
                    docMenu(currentDoc);
                }
                else
                {
                    Console.WriteLine("Unable to find document");
                }
                break;
            case "3":
                Console.WriteLine("Listing your document");
                currentUser.listDocument();
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice! Please enter a number between 1 and 3.");
                break;
        }
    }
}


//Get Document
Document getDoc(User currentUser)
{
    Console.Write("Enter document name");
    string name = Console.ReadLine();
    foreach (Document doc in documents)
    {
        if (doc.Title == name)
        {
            if (currentUser.Document.Contains(doc))
            {
                return doc;
            }
            else
            {
                Console.WriteLine("You are not a collaborator of this document");
            }
           
        }
    }
    return null;
}
//Document Menu
void docMenu(Document currentDoc)
{
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("===== DOCUMENT MENU =====");
        Console.WriteLine("1. Edit");
        Console.WriteLine("2. Submit for review");
        Console.WriteLine("3. Push back");
        Console.WriteLine("4. Approve ");
        Console.WriteLine("5. Reject ");
        Console.WriteLine("6. Add Collaborator ");
        Console.WriteLine("7. Set file conversion type ");
        Console.WriteLine("8. Produce converted file ");
        Console.WriteLine("9. Show document Content");
        Console.WriteLine("0. Stop editing");
        Console.Write("Enter your choice: ");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Edit.");
                break;
            case "2":
                Console.WriteLine("Submit ");
                break;
            case "3":
                Console.WriteLine("Push back");
                break;
            case "4":
                Console.WriteLine("Approve");
                break;
            case "5":
                Console.WriteLine("Reject");
                break;
            case "6":
                Console.WriteLine("add collab");

                break;
            case "7":
                Console.WriteLine("set file type");
                break;
            case "8":
                Console.WriteLine("produce converted file");
                break;
            case "9":
                Console.WriteLine("Show document content");
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice! Please enter a number between 1 and 9.");
                break;
        }
    }
}