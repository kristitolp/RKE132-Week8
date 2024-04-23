
using System.Runtime.InteropServices;

string folderPath = @"C:\Users\Krist\Desktop\data\";
string heroesFile = "heroes.txt";
string villainsFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroesFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainsFile));
string[] weapon = { "Gun", "Fork", "LightSaber", "sword", "spear" };

//string[] heroes = { "Spiderman", "Batman", "Iron-Man", "Lembit", "Kalevipoeg"};
//string[] villains = { "Lord farquad,", "Joker", "Riddler", "Thanos", "Voldemort" };




string hero = GetRandomValueFromArray(heroes);
string heroweapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} is saving the day with {heroweapon} ");
Console.WriteLine($"The has {heroHP} HP");



string villain = GetRandomValueFromArray(villains);
int villainHP = GetCharacterHP(villain);
int villainStrikeStreingth = villainHP;
Console.WriteLine($"Today {villain} tries to take over the world, he has {villainHP} HP");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStreingth);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}
Console.WriteLine($"Hero {hero} HP:{heroHP}");
Console.WriteLine($"villain {villain} HP:{villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saved the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine("Dark side wins!");
}
else
{
    Console.WriteLine("Its a draw");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();

    int randomIndex = rnd.Next(0, someArray.Length);
    string randomeStringFromArray = someArray[randomIndex];
    return randomeStringFromArray;

}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit a target!");

    }
    return strike;

}