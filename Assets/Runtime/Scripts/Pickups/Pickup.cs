using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pickup : MonoBehaviour, IPlayerCollisionReaction
{
    [SerializeField] private AudioClip pickupAudio;

    [SerializeField] private GameObject model;

    public void OnPickedUp(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.GameMode.OnCherryPickedUp();

        AudioSource audioSource = GetComponent<AudioSource>();
        AudioUtility.PlayAudioCue(audioSource, pickupAudio);

        model.SetActive(false);
        Destroy(gameObject, pickupAudio.length);
    }

    public void ReactToPlayerCollision(in PlayerCollisionInfo collisionInfo)
    {
        OnPickedUp(collisionInfo);
    }
}
