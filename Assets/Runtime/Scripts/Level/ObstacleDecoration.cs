using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObstacleDecoration : MonoBehaviour
{
    //Audio Cue
    [SerializeField] private AudioClip collisionAudio;
    [SerializeField] private Animation collisionAnimation;
    private AudioSource audioSource;
    private AudioSource AudioSource => audioSource == null ? audioSource = GetComponent<AudioSource>() : audioSource;

    //Animation Clip feedback

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayCollisionFeedback();
        }
    }

    public void PlayCollisionFeedback()
    {
        AudioUtility.PlayAudioCue(AudioSource, collisionAudio);
        if (collisionAnimation != null)
        {
            collisionAnimation.Play();
        }
    }
}
