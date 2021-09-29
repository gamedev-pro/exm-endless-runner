using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pickup : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1;
    [SerializeField] private AudioClip pickupAudio;

    [SerializeField] private GameObject model;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    public void OnPickedUp()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioUtility.PlayAudioCue(audioSource, pickupAudio);

        model.SetActive(false);
        Destroy(gameObject, pickupAudio.length);
    }
}
