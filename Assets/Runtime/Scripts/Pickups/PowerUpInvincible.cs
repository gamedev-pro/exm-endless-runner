public class PowerUpInvincible : PowerUp
{
    protected override void EndPowerUp(in PlayerCollisionInfo collisionInfo)
    {
    }

    protected override void StartPowerUp(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.Player.SetInvincible(PowerUpTime);
    }
}
