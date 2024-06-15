namespace ClassVideoGame
{
    internal class Program
    {
        static void DisplayVitory(string winner, int round)
        {
            Console.WriteLine($"After {round} round(s), {winner} wins!");
        }

        static void Main(string[] args)
        {
            int rounds = 0;
            Character hero = new Character("Popop", 10, 6, 2, 80);
            Character foe = new Character("EvilMan", 10, 5, 3, 80);

            while (hero.IsAlive() && foe.IsAlive())
            {
                rounds++;

                hero.Attack(foe);
                if (foe.IsAlive())
                {
                    foe.Attack(hero);
                }
            }

            if (hero.IsAlive())
            {
                DisplayVitory(hero.Name, rounds);
            }
            else
            {
                DisplayVitory(foe.Name, rounds);
            }
        }
    }
}
