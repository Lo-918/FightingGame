using System.ComponentModel;

int playerHP;
int oppHP;
int damage;
string playerName;
int oppNameRandomizer;
string oppName;
int hitRandomizer;
int poisoned = 0;
int poisonRandomizer;
string restart = "R";       //variablen är satt till R redan från början så att loopen körs en första gång

while (restart == "R")      //hela spelet är i while loopen eftersom det ska kunna göras flera gånger om man vill starta om
{
    playerHP = 100;     //sätts till hundra i loopen så det sker även om man startar om
    poisoned = 0;       //gör så att man inte börjar med att vara förgiftad även om man var det när man dog

    oppNameRandomizer = Random.Shared.Next(3);      //väljer ett slumpmässigt tal av 0, 1 eller 2 som nedan används för att välja motståndarens namn

    if (oppNameRandomizer == 0)
    {
        oppName = "The evil witch Freya";
        oppHP = 80;
    }
    else if (oppNameRandomizer == 1)
    {
        oppName = "The rotting zombie";
        oppHP = 100;
    }
    else
    {
        oppName = "The huge tarantula";
        oppHP = 120;
    }

    Console.WriteLine("What is your name? Press enter to confirm.");
    playerName = Console.ReadLine();

    while (playerName.Length == 0 || playerName.Length >= 12)       //playerName.Length läser hur många tecken som finns i playerName och tesar om det är noll (ingen text) eller mer än 12 tecken
    {
        Console.WriteLine("Please input a name with a maximum of 12 characters.");
        playerName = Console.ReadLine();        //man måste skriva ett namn och det får inte vara längre än 12 tecken, annars behöver man skriva ett nytt namn
    }

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
            Console.WriteLine("Your attack missed.");     //när man missar subraheras aldrig skadan från motståndarens HP
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

        if (oppName == "The evil witch Freya")
        {
            damage = Random.Shared.Next(5, 16);
            poisonRandomizer = Random.Shared.Next(6);       //det är 1/6 chans att bli förgiftad
            hitRandomizer = 3;      //gör så att Freya aldrig kan missa även om spelaren gjorde det

            if (poisonRandomizer == 0)
            {
                poisoned = poisoned + 4;        //poisoned lagrar hur många rundor till man ska vara förgiftad i, d.v.s. antalet rundor av förgiftning man har kvar plus 4
                Console.WriteLine("You have been poisoned.");
            }

        }
        else if (oppName == "The huge tarantula")
        {
            damage = Random.Shared.Next(1, 6) * 2;
            poisonRandomizer = Random.Shared.Next(6);
            hitRandomizer = Random.Shared.Next(4);      //det är 1/4 chans att spindeln missar

            if (poisonRandomizer == 0)
            {
                poisoned = poisoned + 2;        //poisoned lagrar hur många rundor till man ska vara förgiftad i, d.v.s. antalet rundor av förgiftning man har kvar plus 2
                Console.WriteLine("You have been poisoned.");
            }
        }
        else
        {
            damage = Random.Shared.Next(1, 11);
            hitRandomizer = Random.Shared.Next(4);      //det är 1/4 chans att zombien missar
        }

        if (poisoned > 0)       //poisoned lagrar antalet rundor man ska vara förgiftad i, om det är noll är man inte förgiftad
        {
            Console.WriteLine($"You take {poisoned} poison damage.");
            damage = damage - poisoned;     //man tar mer skada om man ska vara förgiftad i många rundor för då är man "mer" förgiftad
            poisoned--;     //poisoned minskar med 1 varje runda så att man inte är förgiftad för evigt
        }

        if (hitRandomizer == 0)     //gör så att motstådaren har en chans att missa
        {
            Console.WriteLine($"{oppName}'s attack missed.");
        }
        else
        {
            playerHP = playerHP - damage;
            Console.WriteLine($"{oppName} deals {damage} damage to {playerName}.");
        }

        Console.WriteLine("");

        playerHP = Math.Max(playerHP, 0);       //väljer det största talet av spelarens HP och 0, d.v.s. om HP är negativt blir den satt till 0
        oppHP = Math.Max(oppHP, 0);

        Console.Write($"{playerName} {playerHP} HP - ");        //använder Write istället för WriteLine så att nästa rad av koden forstätter skiva på samma rad i terminalen
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