using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Pickup : MonoBehaviour, IPlayerCollisionReaction
{
    [SerializeField] private AudioClip pickupAudio;

    [SerializeField] private GameObject model;

    protected abstract void ExecutePickupBehaviour(in PlayerCollisionInfo collisionInfo);

    protected virtual float LifeTimeAfterPickedUp => pickupAudio.length;

    public void OnPickedUp(in PlayerCollisionInfo collisionInfo)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioUtility.PlayAudioCue(audioSource, pickupAudio);
        model.SetActive(false);
        Destroy(gameObject, LifeTimeAfterPickedUp);
        ExecutePickupBehaviour(collisionInfo);
    }

    public void ReactToPlayerCollision(in PlayerCollisionInfo collisionInfo)
    {
        OnPickedUp(collisionInfo);
    }
}
