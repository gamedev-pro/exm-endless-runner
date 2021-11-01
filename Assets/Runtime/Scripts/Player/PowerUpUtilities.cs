using UnityEngine;

public static class PowerUpUtilities
{
    public static bool IsInvincible(this PlayerController player)
    {
        PowerUpBehaviour_Invincible invincibleBehaviour = player.GetComponentInChildren<PowerUpBehaviour_Invincible>();
        return invincibleBehaviour != null && invincibleBehaviour.IsPowerUpActive;
    }
}