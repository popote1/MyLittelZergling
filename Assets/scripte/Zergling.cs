namespace scripte
{
    public class Zergling
    {
    
        private int _health;
        public int Health
        {
            get =>  _health ;
            set
            {
                if (value > 100)
                {
                    _health = 100;
                    return;
                }

                if (value <= 0)
                {
                    _health = 0;return;
                }
                _health = value;
            }
        }

        private int _food;
        public int Food
        {
            get => _food;
            set
            {
                if (value <= 0)
                {
                    Health -= 1;
                    Power -= 1;
                
                    _food = 0;
                    return;
                }

                if (value >= 100)
                {
                    Health += 10;
                    _food = 100;
                    return;
                }

                _food = value;
            }
        }

        private int _power;

        public int Power
        {
            get => _power;
            set
            {
                if (value > 70)
                {
                    ExostStat = 0;}
                else if (value < 71 && value > 29)
                {
                    ExostStat = 1;
                }
                else if (value < 30)
                {
                    ExostStat = 2;}
                if (value >= 100)
                {
                    _power = 100;
                    return;
                }
                if (value <= 0)
                {
                    Health -= 2;
                    _power = 0;
                    return;

                }
                
                _power = value;
            }
        }

       

        public int ExostStat { get; set; }
        
    

        public Zergling(int health, int Food, int Power)
        {
            _health = health;
            _food = Food;
            _power = Power;
        }
    }
}