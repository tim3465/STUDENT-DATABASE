using System.IO.Pipes;
using System.Runtime.Serialization.Formatters;

string[] names = { "Justin Jones", "Zach Buth", "Omar Abdulla", "Ethan Thomas", "Joe Heath", "Forrest Verellen", "Doug Chu", "Maya Araquil", "Shane Chastain", "Timothy Montague", "Maria Ragone" };
string[] towns = { "Columbus", "Grand Rapids", "Dearborn", "Rolla", "Howell", "Traverse City, MI", "Poughkeepsie", "West bloomfield", "Rochester Hills", "Clio", "Farmington Hills" };
string[] foods = { "Baja Blast", "Pizza", "Cheese Pizza", "Hot Wings", "Tacos", "Spaghetti", "Sushi", "Sinigang", "Pizza", "Mole", "Lasagna" };


//Main part of the program 
while (true)
{
    Console.Clear();
    int caseNumber=0;
    //This while loop controls a user menu that accesses methods.
    //Which displays student information 
    while (true)
    {
        Console.WriteLine("Welcome to the C sharp student database. \n" +
            "Please make your selection by number  \n" +
            "1.\t\t To see a list of all students\n" +
            "2.\t\t To Access a student's information by number\n" +
            "3.\t\t To Acces a student's information by name");
        caseNumber = Convert.ToInt32(Console.ReadLine());
        if (caseNumber >= 1 && caseNumber <= 3)
        {
            int entry;
            switch (caseNumber)
            {
                case 1:
                    SeeSrudentList(names);
                    break;
                case 2:
                    entry = StudentInfomationByNumber(names);
                    ListingFoodOrTown(entry, names, foods, towns);
                    break;
                case 3:
                    entry = SerchByName(names);
                    ListingFoodOrTown(entry, names, foods, towns);
                    break;
            }

            break;
        }
        else
        {
            Console.WriteLine("Invalid entry please enter a number between 1 and 3 ");
        }
    }
    //The user will decide whether he or she wishes to enter another name
    //or exit the program 
    string anser;
    while (true)
    {
        Console.Write("\nWould you like to learn about another student? Enter \"y\" or \"n\":");
        anser = Console.ReadLine();
        if (anser == "n" || anser == "y")
        {
            break;
        }
        else
        {
            Console.WriteLine("invalid entry Please try again");
        }
    }
    if (anser=="n")
    {
        break;
    }

}
Console.WriteLine("\n\nThank you have a nice day!!\n\n");

//metheds*******************************************************************

//Lists all the names in the class with the corresponding number 
static void SeeSrudentList(string[] names)
{
    Console.Clear();
    Console.WriteLine("Here is the list of names\n\n");
    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($"{i + 1}. \t{names[i]}");
    }
}
//Selects the student by number. The user enters a number,
//then the name is displayed 
static int StudentInfomationByNumber(string[] names)
{
    int entry;
    while (true)
    {
        Console.Clear();
        Console.Write($"Which student would you like to learn more about? Enter a number 1-{names.Length}:");

        entry = int.Parse(Console.ReadLine());

        if (entry > 0 && entry <= names.Length)
        {
            entry -= 1;
            break;
        }
        else
        {
            Console.WriteLine("Number outer range please try again ");
        }
    }
    return entry;
}


//Searches the names array by the name that is entered.
//Returns the integer that represents that name. 
static int SerchByName(string[] names)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Enter the name you wish to search for ");
        string serchNames = Console.ReadLine().Trim();
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].ToLower().Contains(serchNames.ToLower()))
            {
                Console.WriteLine($"{i} \t\t{serchNames}");
                return i;
            }
        }
        Console.WriteLine("Name not found please try again ");
    }
}

//The user is given an option to display either the person's favorite food
//or hometown using the given integer "entry" 
static void ListingFoodOrTown(int entry, string[] names, string[] foods, string[] towns)
{
    string entryString;
    Console.Write($"\nStudent is {names[entry]}. What would you like to know? Enter \"hometown\" or \"favorite food\":");
    while (true)
    {
        entryString = Console.ReadLine().ToLower().Trim();
        if ("favorite food".Contains(entryString) ||"hometown".Contains(entryString))
        {
            if ("favorite food".Contains(entryString))
            {
                Console.WriteLine($"\n{names[entry]} favorite food is {foods[entry]}");
            }
            else
            {
                Console.WriteLine($"\n{names[entry]} hometown is {towns[entry]}");
            }
            break;
        }
        else
        {
            Console.Write("That category does not exist. Please try again. Enter \"hometown\" or \"favorite food\": ");
        }
    }
}