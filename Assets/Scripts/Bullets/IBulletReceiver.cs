namespace Assets.Scripts.Bullets
{
    public interface IBulletReceiver
    {
        void Hit(IBulletShooter bulletShooter);
    }
}
