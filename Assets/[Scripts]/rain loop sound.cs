using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoopingTileSound : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioClip tileSound;
    
    [Range(0f, 1f)]
    [SerializeField] private float volume = 1.0f;

    [Header("Behavior")]
    [Tooltip("If true, sound stops when player steps off the tile. If false, it keeps looping forever once stepped on.")]
    [SerializeField] private bool stopWhenPlayerExits = false;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true; // Set the audio source to loop automatically
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tileSound != null && !audioSource.isPlaying)
            {
                audioSource.clip = tileSound;
                audioSource.volume = volume;
                audioSource.Play(); // Starts looping continuous audio
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optional: Stop the looping audio when the player steps off the tile
        if (stopWhenPlayerExits && other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}