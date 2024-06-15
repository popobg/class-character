using System.Text.RegularExpressions;

namespace ClassVideoGame
{
    internal class Character
    {
        private string _name;
        private int _healthPoint;
        private int _strength;
        private int _defense;
        private int _dexterity;
        private Random randomObject = new Random();

        public Character(string name, int hp, int dam, int def, int dext)
        {
            this.Name = name;
            this.HP = hp;
            this.Strength = dam;
            this.Defense = def;
            this.Dexterity = dext;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                // letters, underscores, digits are authorized
                if (string.IsNullOrEmpty(value) || !(Regex.Match(value, @"[\w\-]+", RegexOptions.IgnoreCase).Success))
                {
                    return;
                }

                this._name = value;
            }

        }

        public int HP
        {
            get
            {
                return this._healthPoint;
            }
            set
            {
                if (value < 0)
                {
                    this._healthPoint = 0;
                }
                else
                {
                    this._healthPoint = value;
                }
            }

        }

        public int Strength
        {
            get
            {
                return this._strength;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                this._strength = value;
            }

        }

        public int Defense
        {
            get
            {
                return this._defense;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                this._defense = value;
            }

        }

        public int Dexterity
        {
            get
            {
                return this._dexterity;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    return;
                }

                this._dexterity = value;
            }

        }

        public bool IsAlive()
        {
            if (this._healthPoint == 0)
            {
                return false;
            }
            return true;
        }

        // randomly generates damage
        public int GenerateDamage()
        {
            // chance to miss the blow
            if (randomObject.Next(100) > this.Dexterity)
            {
                return 0;
            }

            // +2 for critical hit
            return randomObject.Next(this.Strength - 3, this.Strength + 2);
        }

        public void Attack(Character opponent)
        {
            int damage = this.GenerateDamage();

            int totalDamage = damage - opponent._defense;

            if (totalDamage <= 0)
            {
                Console.WriteLine($"{this.Name} made no damage to {opponent.Name}. {opponent.Name} still has {opponent.HP}HP left.");
                Console.WriteLine();
                return;
            }

            opponent.HP -= totalDamage;

            Console.WriteLine($"{opponent.Name} took {totalDamage} damage(s) from {this.Name}. {opponent.Name} now has {opponent.HP}HP left.");
            Console.WriteLine();
        }
    }
}
