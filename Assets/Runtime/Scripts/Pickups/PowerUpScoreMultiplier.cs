using System.Collections;
using UnityEngine;

public class PowerUpScoreMultiplier : PowerUp
{
    [SerializeField] private float powerUpTime = 30;

    [SerializeField] private int scoreMultiplier = 2;
    [SerializeField] private GameObject powerUpParticlesPrefab;

    protected override float LifeTimeAfterPickedUp => powerUpTime * 1.1f;

    protected override sealed void ExecutePickupBehaviour(in PlayerCollisionInfo collisionInfo)
    {
        StartCoroutine(PowerUpCoroutine(collisionInfo));
    }

    private IEnumerator PowerUpCoroutine(PlayerCollisionInfo collisionInfo)
    {
        transform.SetParent(null);
        GameObject particles = Instantiate(powerUpParticlesPrefab, collisionInfo.Player.transform);
        collisionInfo.GameMode.TemporaryScoreMultipler = scoreMultiplier;
        yield return new WaitForSeconds(powerUpTime);
        collisionInfo.GameMode.TemporaryScoreMultipler = 0;
        Destroy(particles);
    }
}
