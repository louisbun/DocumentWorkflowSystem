// See https://aka.ms/new-console-template for more information
using DocumentWorkflowSystem;
using DocumentWorkflowSystem.Factory;
using System.ComponentModel.Design;
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
Document josephDoc = grantProposalFactory.createDocument(joseph, "gp1");
Document anotherDoc = grantProposalFactory.createDocument(yunze, "yunze story");
Document nextDoc = technicalReportFactory.createDocument(zhenkang, "ZhenKang story");


//Adding document to User 
joseph.addDocument(josephDoc);
yunze.addDocument(anotherDoc);
zhenkang.addDocument(nextDoc);

//Adding to document List
documents.Add(josephDoc);
documents.Add(anotherDoc);
documents.Add(nextDoc);

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

        string? input = Console.ReadLine();
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
                User? currentUser = login();
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
    string? name = Console.ReadLine();
    User user = new User(name);
    users.Add(user);
}

//Verify User login
User? login()
{
    Console.Write("Enter name: ");
    string? name = Console.ReadLine();
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

        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("New document.");
                docTypeMenu(currentUser);
                
                break;
            case "2":
                Console.WriteLine("Edit document ");
                Document currentDoc = getDoc(currentUser);
                if(currentDoc != null)
                {
                    docMenu(currentDoc, currentUser);
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

void docTypeMenu(User currentUser)
{
    Console.WriteLine("Document Types");
    Console.WriteLine("1. Grant Proposal");
    Console.WriteLine("2. Technical Report");
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("Enter title for your document: ");
        string title = Console.ReadLine();

        Console.WriteLine("Enter document type: ");
        string input = Console.ReadLine();
        Console.WriteLine(input);
        switch (input)
        {
            case "1":
                Document grantDoc = currentUser.createDocument("Grant",title);
                documents.Add(grantDoc);
                Console.WriteLine("Grant Proposal document created.");
                exit = true;
                break;
            case "2":
                Document technicalDoc = currentUser.createDocument("Technical",title);
                documents.Add(technicalDoc);
                Console.WriteLine("Technical Report document created.");
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice! Please enter a number between 1 and 2.");
                break;
        }
    }

}

//Get Document
Document getDoc(User currentUser)
{
    Console.Write("Enter document name");
    string? name = Console.ReadLine();
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
void docMenu(Document currentDoc, User currentUser)
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

        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Edit.");
                editDocument(currentDoc);
                break;
            case "2":
                Console.WriteLine("Submit");
                User? approver;
                if (currentDoc.Approver == null)
                {
                    approver = login();
                    if (approver != null)
                    {
                        currentDoc.assignApprover(approver);
                    }
                    else
                    {
                        Console.WriteLine("No valid user found");
                    }
                }
                
                
                currentDoc.notifyObserver("submit", currentUser);
                break;
            case "3":
                Console.WriteLine("Push back");
                currentDoc.notifyObserver("push back", currentUser);
                break;
            case "4":
                Console.WriteLine("Approve");
                currentDoc.notifyObserver("approve", currentUser);
                break;
            case "5":
                Console.WriteLine("Reject");
                currentDoc.notifyObserver("reject", currentUser);
                break;
            case "6":
                Console.WriteLine("add collab");
                User collab = login();
                if(collab != null)
                {
                    currentDoc.registerObserver(collab, currentUser);
                }
                else
                {
                    Console.WriteLine("Unable to find collaborator");
                }
                break;
            case "7":
                Console.WriteLine("Set file type");
                setConversionType(currentDoc);
                break;
            case "8":
                Console.WriteLine("produce converted file");
                printConversionDetails(currentDoc);
                break;
            case "9":
                Console.WriteLine("Show document content");
                showDocContent(currentDoc);
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

void editDocument(Document currentDoc)
{
    Console.WriteLine("Add text to document");
    string? text = Console.ReadLine();
    currentDoc.Content += "\n" + text;
}
void showDocContent(Document currentDoc)
{
    Console.WriteLine("Header: " + currentDoc.Header);
    Console.WriteLine("Body Content: " + currentDoc.Content);
    Console.WriteLine("Footer: " + currentDoc.Footer);
}


// Set conversion type for the document
void setConversionType(Document document)
{
    Console.WriteLine("Choose conversion format:");
    Console.WriteLine("1. Word");
    Console.WriteLine("2. PDF");
    string? choice = Console.ReadLine();

    ConvertBehaviour converter = null;
    switch (choice)
    {
        case "1":
            converter = new WordConvert();  // WordConvert class
            break;
        case "2":
            converter = new PDFConvert();   // PDFConvert class
            break;
        default:
            Console.WriteLine("Invalid choice.");
            return;
    }

    Console.WriteLine("Do you want to add a watermark? (yes/no)");
    string? watermarkChoice = Console.ReadLine();

    if (watermarkChoice.ToLower() == "yes")
    {
        Console.Write("Enter watermark text: ");
        string? watermarkText = Console.ReadLine();
        converter = new WatermarkDecorator(converter, watermarkText);  // Add watermark decorator
    }

    document.SetConvertBehaviour(converter);  // Set the conversion behaviour for the document
    Console.WriteLine("Conversion type set successfully!");
}


// Print conversion details
void printConversionDetails(Document document)
{
    if (document.GetConvertBehaviour() != null)
    {
        // Output the conversion type as "PDF" or "Word"
        string? conversionType = document.GetConvertBehaviour() is PDFConvert ? "PDF" : "Word";
        Console.WriteLine($"Current conversion type: {conversionType}");

        document.GetConvertBehaviour().convert();

        // Check if a watermark decorator is applied
        if (document.GetConvertBehaviour() is WatermarkDecorator watermarkDecorator)
        {
            Console.WriteLine($"Watermark applied: {watermarkDecorator.WaterMarkText}");
        }
        else
        {
            Console.WriteLine("No watermark applied.");
        }
    }
    else
    {
        Console.WriteLine("No conversion type set for this document.");
    }
}
