using System.ComponentModel;

int HP = 100;
int oppHP = 100;
int damage;

while (HP > 0 && oppHP > 0)
{
    damage = Random.Shared.Next(1, 11);
    HP = HP - damage;
    Console.Write($"PlayerA {HP}  -  ");
    damage = Random.Shared.Next(1, 11);
    oppHP = oppHP - damage;
    Console.WriteLine($"{oppHP} PlayerB");
    Console.WriteLine("");
}

if (HP <= 0 && oppHP <= 0)
{
    Console.WriteLine("Det blev oavgjort!");
}
else if (HP <= 0 && oppHP >= 0)
{
    Console.WriteLine("Du förlorade!");
}
else if (HP >= 0 && oppHP <= 0)
{
    Console.WriteLine("Du vann!");
}
else
{
    Console.WriteLine("Ööööööh... detta är en bugg du ska inte kunna se den här texten");
}

Console.ReadLine();