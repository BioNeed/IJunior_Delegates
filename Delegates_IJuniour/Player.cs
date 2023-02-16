namespace Task_Delegates
{
    public class Player
    {
        private readonly int _id;
        private float _health;
        private float _armor;

        public Player(float health, float armor, int id)
        {
            _health = health;
            _armor = armor;
            _id = id;
        }

        public event Action<int, float, float>? HealthChanged;

        public event Func<int, float>? HealthInit;

        public float Health => _health;

        public void InitHealthFromFile()
        {
            if (File.Exists($"user_{_id}.data") && HealthInit != null)
            {
                _health = HealthInit.Invoke(_id);
            }
        }

        public void ApplyDamage(float damage)
        {
            float damageTaken = damage - _armor;
            _health -= damageTaken;
            _armor /= 2;

            HealthChanged?.Invoke(_id, _health, damageTaken);
        }
    }
}