using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TileSoundTrigger : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioClip tileSound;
    
    [Range(0f, 1f)]
    [SerializeField] private float volume = 1.0f;

    private AudioSource audioSource;

    private void Awake()
    {
        // Get the AudioSource component on this tile
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object stepping on the tile is tagged "Player"
        if (other.CompareTag("Player"))
        {
            if (tileSound != null)
            {
                // PlayOneShot allows sound to play without stopping previous audio
                audioSource.PlayOneShot(tileSound, volume);
            }
        }
    }
}