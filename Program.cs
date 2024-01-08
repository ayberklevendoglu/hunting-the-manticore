int round = 1;
int manticoreHealth = 10;
int cityHealth = 15;

int distanceToCity = PromptForNumber("Player 1, how far away from the city do you want to station the Manticore?");
Console.Clear();

Console.WriteLine("Player 2, it is your turn now.");


while (cityHealth > 0 && manticoreHealth > 0)
{
    ColoredWriteLine("-----------------------------------------------------------", ConsoleColor.Gray);
    ColoredWriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10",ConsoleColor.Gray);
    ColoredWriteLine($"The cannon is expected to deal {CannonDamage(round)} damage this round.",ConsoleColor.Gray);
    int cannonRange = PromptForNumber("Enter desired cannon range: ");

    DisplayAttackResult(cannonRange,distanceToCity);

    round++;
}

DisplayWinner(manticoreHealth);

void DisplayAttackResult(int target,int distance)
{
    if (target == distance)
    {
        ColoredWriteLine("That round was a DIRECT HIT!", ConsoleColor.Green);
        manticoreHealth -= CannonDamage(round);
    }
    else if (target > distance)
    {
        ColoredWriteLine("That round OVERSHOT the target.", ConsoleColor.Red);
        cityHealth--;
    }
    else
    {
        ColoredWriteLine("That round FELL SHORT of the target.", ConsoleColor.Red);
        cityHealth--;
    }
}

int PromptForNumber(string message)
{
    Console.Write(message);
    int response = int.Parse(Console.ReadLine());
    while (response > 100 || response <= 0)
    {
        ColoredWriteLine("Please enter a number between 0 and 100", ConsoleColor.Red);
        ColoredWriteLine(message, ConsoleColor.Gray);
        response = int.Parse(Console.ReadLine());
    }
    return response;
}

int CannonDamage(int number)
{
    int damage;
    if (number % 3 == 0 && number % 5 == 0) damage = 10;
    else if (number % 3 == 0 || number % 5 == 0) damage = 3; 
    else damage = 1;

    return damage;
}

void DisplayWinner(int monsterHealth)
{
    if ( monsterHealth <= 0 ) ColoredWriteLine("The Manticore has been destroyed! The city of Consolas has been saved!",ConsoleColor.Green);
    else ColoredWriteLine("The city of Consolas has been destroyed! The Manticore has won!", ConsoleColor.Red);
}

void ColoredWriteLine(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
}

