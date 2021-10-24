using System.Collections;
using UnityEngine;

public abstract class PowerUp : Pickup
{
    [SerializeField] private float powerUpTime = 30;

    [SerializeField] private GameObject powerUpParticlesPrefab;

    protected override float LifeTimeAfterPickedUp => powerUpTime * 1.1f;

    protected override sealed void ExecutePickupBehaviour(in PlayerCollisionInfo collisionInfo)
    {
        StartCoroutine(PowerUpCoroutine(collisionInfo));
    }

    private IEnumerator PowerUpCoroutine(PlayerCollisionInfo collisionInfo)
    {
        transform.SetParent(null);
        GameObject particles = particles = Instantiate(powerUpParticlesPrefab, collisionInfo.Player.transform);

        StartPowerUp(collisionInfo);

        yield return new WaitForSeconds(powerUpTime);

        Destroy(particles);

        EndPowerUp(collisionInfo);
    }

    protected abstract void StartPowerUp(in PlayerCollisionInfo collisionInfo);

    protected abstract void EndPowerUp(in PlayerCollisionInfo collisionInfo);
}
