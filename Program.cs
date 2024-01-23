// Prompt greetings and options
// If option is not operable, display "error" message and prompt again
// If user types "S", show all TODO features
// If user types "A", prompt to add to TODO
// If the above prompt is empty, display error and prompt again
// Else if description is added to the TODO, prompt greetings and options.
// If user types "R", prompt message for which TODO to remove (index of the option)
// If empty, or invalid index is added, display error and prompt again
// Else if correct index is added, remove the item and display list of TODO
// If user types "E", exit immediately.

Console.WriteLine("Hello\n");
PromptGreetingAndOptions();

var todoList = new List<string>();

while (true)
{
    string userInput = SelectUserOption();

    switch (userInput)
    {
        case "S":
            ShowAllFeatures();
            break;
        case "A":
            AddFeature();
            break;
        case "R":
            RemoveFeature();
            break;
        case "E":
            Environment.Exit(0);
            break;
    }

    PromptGreetingAndOptions();
}



void PromptGreetingAndOptions()
{
    string message = "What do you want to do?\n[S]ee all TODOs\n[A]dd a TODO\n[R]emove a TODO\n[E]xit";
    Console.WriteLine(message);
}

string SelectUserOption()
{
    string userInput = Console.ReadLine().ToUpper();

    while (userInput != "S" && userInput != "A" && userInput != "R" && userInput != "E")
    {
        Console.WriteLine("\nIncorrect Input");
        PromptGreetingAndOptions();
        userInput = Console.ReadLine().ToUpper();
    }

    return userInput;
}

void ShowAllFeatures()
{
    if (todoList.Count == 0)
    {
        Console.WriteLine("No TODO has been added yet.\n");
        return;
    }

    for (var i = 0; i < todoList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoList[i]}\n");
    }
}

void AddFeature()
{
    string description;
    do
    {
        Console.WriteLine("\nEnter the TODO description...");
        description = Console.ReadLine();
        if (string.IsNullOrEmpty(description))
            Console.WriteLine("The description cannot be empty.");
        else if (todoList.Contains(description))
            Console.WriteLine("The description must be unique.");
        else
        {
            todoList.Add(description);
            Console.WriteLine($"TODO successfully added: {description}\n");
            break;
        }
    } while (string.IsNullOrEmpty(description) || todoList.Contains(description));
}

void RemoveFeature()
{
    if (todoList.Count == 0)
    {
        Console.WriteLine("No TODOs to remove.\n");
        return;
    }

    Console.WriteLine("\nSelect the index of the TODO you want to remove: ");
    ShowAllFeatures();

    int index;
    while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= todoList.Count)
        Console.WriteLine("The given index is not valid.");

    todoList.RemoveAt(index);
    ShowAllFeatures();
}