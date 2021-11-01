using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObstacleDecoration : MonoBehaviour
{
    [SerializeField] private AudioClip collisionAudio;

    private AudioSource audioSource;

    private AudioSource AudioSource => audioSource == null ? audioSource = GetComponent<AudioSource>() : audioSource;

    public virtual void PlayCollisionFeedback()
    {
        AudioSource.PlayAudioCue(collisionAudio);
        Animation animComp = GetComponentInChildren<Animation>();
        if (animComp != null)
        {
            animComp.Play();
        }
    }
}
