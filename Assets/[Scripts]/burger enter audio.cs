using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OneTimeTileSound : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioClip tileSound;
    
    [Range(0f, 1f)]
    [SerializeField] private float volume = 1.0f;

    private AudioSource audioSource;
    private bool hasBeenSteppedOn = false; // Tracks if the tile was already used

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger if it's the Player AND hasn't been stepped on yet
        if (other.CompareTag("Player") && !hasBeenSteppedOn)
        {
            if (tileSound != null)
            {
                audioSource.PlayOneShot(tileSound, volume);
            }

            // Lock it so it never plays again
            hasBeenSteppedOn = true; 
        }
    }
}