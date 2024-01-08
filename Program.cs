int round = 1;
int manticoreHealth = 10;
int cityHealth = 15;

int distanceToCity = PromptForNumber("Player 1, how far away from the city do you want to station the Manticore?");
Console.Clear();

Console.WriteLine("Player 2, it is your turn now.");


while (cityHealth > 0 && manticoreHealth > 0)
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
    Console.WriteLine($"The cannon is expected to deal {CannonDamage(round)} damage this round.");
    int cannonRange = PromptForNumber("Enter desired cannon range: ");

    if (cannonRange == distanceToCity)
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth -= CannonDamage(round);
    }
    else if(cannonRange > distanceToCity)
    {
        Console.WriteLine("That round OVERSHOT the target.");
        cityHealth--;
    }
    else
    {
        Console.WriteLine("That round FELL SHORT of the target.");
        cityHealth--;
    }

    round++;
}

DisplayWinner(cityHealth, manticoreHealth);

int PromptForNumber(string message)
{
    Console.Write(message);
    int response = int.Parse(Console.ReadLine());
    while (response > 100 || response <= 0)
    {
        Console.WriteLine("Please enter a number between 0 and 100");
        Console.Write(message);
        response = int.Parse(Console.ReadLine());
    }
    return response;
}

int CannonDamage(int number)
{
    int damage;
    if (number % 3 == 0 && number % 5 == 0)
    {
        damage = 10;
    } else if (number % 3 == 0 || number % 5 == 0) 
    { 
        damage = 3; 
    }else
    {
        damage = 1;
    }
    return damage;
}

void DisplayWinner(int city,int manticore)
{
    if(manticore == 0 || manticore < 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
    }else if (city == 0 || city < 0)
    {
        Console.WriteLine("The city of Consolas has been destroyed! The Manticore has won!");
    }
}

