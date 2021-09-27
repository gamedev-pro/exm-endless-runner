using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip rollSound;
    private AudioSource audioSource;

    private AudioSource AudioSource => audioSource == null ? audioSource = GetComponent<AudioSource>() : audioSource;

    public void PlayJumpSound()
    {
        Play(jumpSound);
    }

    public void PlayRollSound()
    {
        Play(rollSound);
    }

    private void Play(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.loop = false;
        AudioSource.Play();
    }
}
