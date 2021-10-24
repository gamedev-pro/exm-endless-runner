using UnityEngine;
public class PowerUpInvincible : PowerUp
{
    protected override void ActivatePowerUpBehaviour(PlayerController player)
    {
        player.GetComponentInChildren<PowerUpBehaviour_Invincible>().Activate(PowerUpTime);
    }
}