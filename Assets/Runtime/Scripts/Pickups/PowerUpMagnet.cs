using System.Collections;

public class PowerUpMagnet : PowerUp
{
    protected override void ActivatePowerUpBehaviour(PlayerController player)
    {
        player.GetComponentInChildren<PowerUpBehaviour_Magnet>().Activate(PowerUpTime);
    }
}
