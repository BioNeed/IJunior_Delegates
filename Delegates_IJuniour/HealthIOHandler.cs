namespace Task_Delegates
{
    public class HealthIOHandler
    {
        public static void OnHealthChanged(int id, float health, float damageTaken)
        {
            Console.WriteLine($"Вы получили урона - {damageTaken}");

            File.WriteAllText($"user_{id}.data", health.ToString());
        }

        public static float OnHealthInit(int id)
        {
            var data = File.ReadAllText($"user_{id}.data");
            return float.Parse(data);
        }
    }
}