using System.ComponentModel;

int playerHP;
int oppHP;
int damage;
string playerName;
int oppNameRandomizer;
string oppName;
int hitRandomizer;
string restart = "R";       //variablen är satt till R redan från början så att loopen körs en första gång

while (restart == "R")      //hela spelet är i while loopen eftersom det ska kunna göras flera gånger om man vill starta om
{
    oppHP = 100;        //dessa sätts till hundra i loopen så det sker även om man startar om
    playerHP = 100;
    oppNameRandomizer = Random.Shared.Next(3);      //väljer ett slumpmässigt tal av 0, 1 eller 2 som nedan används för att välja motståndarens namn

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

    while (playerHP > 0 && oppHP > 0)       //loopen fortsätter bara när båda är vid liv, d.v.s. när bådas HP är över noll
    {
        Console.WriteLine("Press enter go continue.");
        Console.ReadLine();     //väntar på att spelaren vill gå vidare

        Console.WriteLine("~~~~~~~~~New round~~~~~~~~~");

        damage = Random.Shared.Next(1, 11);
        hitRandomizer = Random.Shared.Next(4);      //väljer ett slumpmässigt tal av 0, 1, 2 eller 3 för att det ska vara 25% chans för miss & 25% för crit. 1 & 2 gör inget speciellt

        if (hitRandomizer == 0)
        {
            Console.WriteLine("Attack missed");     //när man missar subraheras aldrig skadan från motståndarens HP
        }
        else
        {
            if (hitRandomizer == 3)
            {
                damage = damage * 2;
                Console.WriteLine("Critical hit!");
            }
            oppHP = oppHP - damage;
            Console.WriteLine($"{playerName} deals {damage} damage to {oppName}.");
        }

        damage = Random.Shared.Next(1, 11);
        playerHP = playerHP - damage;
        Console.WriteLine($"{oppName} deals {damage} damage to {playerName}.");

        Console.WriteLine("");

        playerHP = Math.Max(playerHP, 0);       //väljer det största talet av spelarens HP och 0, d.v.s. om HP är negativt blir den satt till 0
        oppHP = Math.Max(oppHP, 0);

        Console.Write($"{playerName} {playerHP} HP - ");
        Console.WriteLine($"{oppHP} HP {oppName}.");

        Console.WriteLine("");
    }

    if (playerHP <= 0 && oppHP <= 0)        //om båda har 0 HP blir det oavgjort
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
    //ReadKey läser det första tecknet man skriver (inget enter krävs)
    //KeyChar gör om det till ett tecken
    //ToString gör om det till en string
    //ToUpper gör om det till versaler
}