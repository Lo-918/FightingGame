using System.ComponentModel;

int playerHP;
int oppHP;
int damage;
string playerName;
int oppNameRandomizer;
string oppName;
int hitRandomizer;
string restart = "R";

while (restart == "R")
{
    oppHP = 100;
    playerHP = 100;
    oppNameRandomizer = Random.Shared.Next(3);

    if (oppNameRandomizer == 0)
    {
        oppName = "The evil witch Freya";
    }
    else if (oppNameRandomizer == 1)
    {
        oppName = "The rotting zombie";
    }
    else
    {
        oppName = "The huge tarantula";
    }

    Console.WriteLine("What is your name? Press enter to confirm.");
    playerName = Console.ReadLine();

    Console.WriteLine($"Get ready for the battle of the ages: {playerName} vs {oppName}");

    while (playerHP > 0 && oppHP > 0)
    {
        Console.WriteLine("Press enter go continue.");
        Console.ReadLine();

        Console.WriteLine("~~~~~~~~~New round~~~~~~~~~");

        damage = Random.Shared.Next(1, 11);
        hitRandomizer = Random.Shared.Next(4);
        
        if (hitRandomizer == 0)
        {
            damage = 0;
        }
        else if (hitRandomizer == 3)
        {
            damage = damage * 2;
        }

        oppHP = oppHP - damage;
        Console.WriteLine($"{playerName} deals {damage} damage to {oppName}.");

        damage = Random.Shared.Next(1, 11);
        playerHP = playerHP - damage;
        Console.WriteLine($"{oppName} deals {damage} damage to {playerName}.");

        Console.WriteLine("");

        Console.Write($"{playerName} {playerHP} HP - ");
        Console.WriteLine($"{oppHP} HP {oppName}.");

        Console.WriteLine("");
    }

    if (playerHP <= 0 && oppHP <= 0)
    {
        Console.WriteLine("Draw!");
    }
    else if (playerHP <= 0 && oppHP >= 0)
    {
        Console.WriteLine("Game over. You lost!");
    }
    else if (playerHP >= 0 && oppHP <= 0)
    {
        Console.WriteLine("YOU WIN!");
    }
    else
    {
        Console.WriteLine("uh oh... this is very much a bug, you shouldnt be able to see this text");
    }

    Console.WriteLine("Press R to restart. Press any other key to end.");
    restart = Console.ReadKey().KeyChar.ToString().ToUpper();
    //Console.ReadKey läser det första tecknet man skriver (inget enter krävs)
    //KeyChar gör om det till ett tecken
    //ToString gör om det till en string
    //ToUpper gör om det till versaler
}