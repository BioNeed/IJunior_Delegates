namespace Task_Delegates
{
    public class Program
    {
        public static void Main()
        {
            var player = new Player(100, 10, 1);

            player.HealthChanged += HealthIOHandler.OnHealthChanged;
            player.HealthInit += HealthIOHandler.OnHealthInit;

            player.InitHealthFromFile();

            player.ApplyDamage(100);
            player.ApplyDamage(10);

            player.HealthChanged -= HealthIOHandler.OnHealthChanged;
            player.HealthInit -= HealthIOHandler.OnHealthInit;
        }
    }
}