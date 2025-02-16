using DocumentWorkflowSystem;
using DocumentWorkflowSystem.Factory;
using System.ComponentModel.Design;

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
Document josephDoc = joseph.createDocument("Grant", "gp1");
Document anotherDoc = yunze.createDocument("Technical", "HellO WORLD!");
Document nextDoc = zhenkang.createDocument("Grant", "Yellow");


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
        Console.WriteLine("========= MENU =========");
        Console.WriteLine("1. Create new user");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. List all users");
        Console.WriteLine("4. List all documents");
        Console.WriteLine("0. Exit");
        Console.WriteLine("========================");
        Console.Write("Enter your choice: ");

        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine();
                Console.WriteLine("\nCreating new user...\n");
                createUser();
                break;
            case "2":
                Console.WriteLine();
                Console.WriteLine("\nStarting login...\n");
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
                Console.WriteLine("\nListing all Users...\n");
                foreach(User u in users)
                {
                    Console.WriteLine(u.Name);
                }
                break;
            case "4":
                Console.WriteLine();
                Console.WriteLine("\nListing all Documents...\n");
                foreach (Document doc in documents)
                {
                    Console.WriteLine($"{doc.Title} ({doc.Owner.Name})");
                }
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("\nInvalid choice! Please enter a number between 1 and 4.\n");
                break;
        }
    }
}

//Create new Users
void createUser()
{
    string? name;
    while (true)
    {
        Console.WriteLine("Enter name: ");
        name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name of user cannot be left empty. Please try again.");
            Console.WriteLine();
        }
        else
        {
            break;
        }
    }
    User user = new User(name);
    users.Add(user);
}

//Verify User login
User? login()
{
    Console.Write("Enter name : ");
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
        Console.WriteLine("\n======= USER MENU =======");
        Console.WriteLine("1. Create new document");
        Console.WriteLine("2. Edit document");
        Console.WriteLine("3. List your documents");
        Console.WriteLine("0. Logout");
        Console.WriteLine("=========================");
        Console.Write("Enter your choice: ");

        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":

                Console.WriteLine("\nCreating new document...\n");
                docTypeMenu(currentUser);
               
                break;
            case "2":
                Console.WriteLine("\nEditing document...\n ");
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
                Console.WriteLine("\nListing your document(s)...\n");
                Console.WriteLine("Documents");
                Console.WriteLine("------------------");
                currentUser.listDocument();
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("\nInvalid choice! Please enter a number between 1 and 3.\n");
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

        Console.WriteLine("Enter document type: ");
        string? input = Console.ReadLine();

        string? title;
        while (true)
        {
            Console.WriteLine("Enter title for your document: ");
            title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title of document cannot be empty. Please enter a valid title.");
                Console.WriteLine();
            }
            else
            {
                break;
            }
        }

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
    Console.Write("Enter document name : ");
    string? name = Console.ReadLine();
    foreach (Document doc in documents)
    {
        if (doc.Title == name)
        {
            if (currentUser.Documents.Contains(doc))
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
        Console.WriteLine("\n====== DOCUMENT MENU ======");
        Console.WriteLine("1. Edit");
        Console.WriteLine("2. Submit for review");
        Console.WriteLine("3. Push back");
        Console.WriteLine("4. Approve ");
        Console.WriteLine("5. Reject ");
        Console.WriteLine("6. Add Collaborator ");
        Console.WriteLine("7. Set file conversion type ");
        Console.WriteLine("8. Produce converted file ");
        Console.WriteLine("9. Show document Content");
        Console.WriteLine("10.Add Document Features");
        Console.WriteLine("0. Stop editing");
        Console.WriteLine("===========================");
        Console.Write("Enter your choice: ");

        string? input = Console.ReadLine();
        switch (input)
        {
            case "1":

                Console.WriteLine("\nEditing document...\n");
                if (currentDoc.Approver == currentUser)
                {
                    Console.WriteLine("Approver CANNOT EDIT!");
                }
                else
                {
                    currentDoc.editDocument();
                }

                break;

            case "2":
                if(currentDoc.Approver == currentUser)
                {
                    Console.WriteLine("Approver cannot submit document!!!");
                }
                else
                {
                    Console.WriteLine("\nSubmitting for review...\n");
                    User? approver;
                    if (currentDoc.Approver == null)
                    {
                        Console.WriteLine("Assigning approver.");
                        approver = login();
                        if (approver != null)
                        {
                            currentDoc.submit(approver);
                            //approver.addDocument(currentDoc); // adding documents to the approver

                        }
                        else
                        {
                            Console.WriteLine("No valid user found");
                        }
                    }
                    else
                    {
                        currentDoc.submit(currentDoc.Approver);
                    }
                }

                break;

            case "3":
                if (currentUser == currentDoc.Approver)
                {
                    // adding comment for push back
                    string? comment;
                    Console.WriteLine("Enter the reason for pushing back: ");
                    comment = Console.ReadLine();

                    currentDoc.pushBack(currentUser, comment);
                    //exit = true;
                }
                else
                {
                    Console.WriteLine("Only the approver can push back.");
                }
                
                break;

            case "4":
                if (currentUser == currentDoc.Approver)
                {
                    currentDoc.approve(currentUser);
                }
                else
                {
                    Console.WriteLine("Only the approver can approve document.");
                }

                break;

            case "5":
                if (currentUser == currentDoc.Approver)
                {
                    // adding comment for reject
                    string? comment;
                    Console.WriteLine("Enter the reason for rejecting: ");
                    comment = Console.ReadLine();

                    currentDoc.reject(currentUser, comment);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Only the approver can reject document.");
                }

                break;

            case "6":
                Console.WriteLine("Adding collaborator...");
                User? collaborator = login();
                if(collaborator != null)
                {
                    if(currentDoc.Owner == currentUser)
                    {
                        //collaborator.addDocument(currentDoc);
                        //currentDoc.registerObserver(collab);

                        currentDoc.addCollaborator(collaborator);
                    }
                    else
                    {
                        Console.WriteLine("Only owner can add collaborator!");
                    }
                }
                else
                {
                    Console.WriteLine("Unable to find collaborator");
                }
                break;

            case "7":
                Console.WriteLine("\nSetting file type...\n");
                setConversionType(currentDoc);
                break;

            case "8":
                Console.WriteLine("\nProduce converted file...\n");
                printConversionDetails(currentDoc);
                break;

            case "9":
                Console.WriteLine("\nShowing document content...\n");
                //showDocContent(currentDoc);
                currentDoc.DisplayDocument();
                break;

            case "10":
                Console.WriteLine("\nAdding document features...\n");
                //addDocumentFeatures(currentDoc);
                Document updatedDoc = addDocumentFeatures(currentDoc); // Capture the returned document
                if (updatedDoc != null)
                {
                    // Replace the document in the list so that changes persist
                    int index = documents.IndexOf(currentDoc);
                    if (index != -1)
                    {
                        documents[index] = updatedDoc;
                    }
                    foreach(User u in currentDoc.Observers)
                    {
                        int userDocIndex = u.Documents.IndexOf(currentDoc);
                        if (userDocIndex != -1)
                        {
                            u.Documents[userDocIndex] = updatedDoc;
                        }
                    }

                    currentDoc = updatedDoc; // Update reference
                }
                break;

            case "0":
                exit = true;
                break;

            default:
                Console.WriteLine("\nInvalid choice! Please enter a number between 1 and 9.\n");
                break;
        }
    }
}

//void editDocument(Document currentDoc)
//{
//    Console.WriteLine("Add text to document");
//    string? text = Console.ReadLine();
//    currentDoc.Content += "\n" + text;
//}

//void showDocContent(Document currentDoc)
//{
//    Console.WriteLine("Header: " + currentDoc.Header);
//    Console.WriteLine("Body Content: " + currentDoc.Content);
//    Console.WriteLine("Footer: " + currentDoc.Footer);
//}



void setConversionType(Document document)
{
    Console.WriteLine("Choose conversion format:");
    Console.WriteLine("1. Word");
    Console.WriteLine("2. PDF");
    Console.Write("Enter a choice ( 1 or 2 ): ");
    int choice = Convert.ToInt32(Console.ReadLine());

    ConvertBehaviour? converter = null;

    switch (choice)
    {
        case 1:
            converter = new WordConvert();
            break;
        case 2:
            converter = new PDFConvert();
            break;
        default:
            Console.WriteLine("\nInvalid choice.\n");
            return;
    }
    BaseConverter baseConverter = choice == 1 ? new WordConverter(converter) : new PDFConverter(converter);

    document.SetConverter(baseConverter);
    Console.WriteLine("Conversion type set successfully!");
}



// Print conversion details
void printConversionDetails(Document document)
{

    if (document != null)
    {
        Console.WriteLine($"Performing conversion for document: {document.Title}");
        document.PerformConvert();
    }
    else
    {
        Console.WriteLine("No conversion type set for this document.");
    }
}

Document addDocumentFeatures(Document currentDoc)
{
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("\n====== ADD DOCUMENT FEATURES ======");
        Console.WriteLine("1. Add Watermark");
        Console.WriteLine("2. Encrypt Document");
        Console.WriteLine("3. Compress Document");
        Console.WriteLine("0. Back to Document Menu");
        Console.WriteLine("===================================");
        Console.Write("Enter your choice: ");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.Write("Enter Watermark Text: ");
                string? watermarkText = Console.ReadLine();
                currentDoc = new WatermarkDecorator(currentDoc, watermarkText); 
                Console.WriteLine("Watermark added.");
                break;
            case "2":
                Console.Write("Enter Encryption Key: ");
                string? encryptionKey = Console.ReadLine();
                currentDoc = new EncryptDecorator(currentDoc, encryptionKey);
                Console.WriteLine("Document encrypted.");
                break;
            case "3":
                currentDoc = new CompressDecorator(currentDoc);
                Console.WriteLine("Document compressed.");
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice! Please enter a valid option.");
                break;
        }
    }
    return currentDoc;
}

