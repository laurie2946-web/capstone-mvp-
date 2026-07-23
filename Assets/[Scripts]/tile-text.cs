using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private GameObject puzzleSolvedText; // Assign your UI Text GameObject here

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object stepping on the tile is tagged "Player"
        if (other.CompareTag("Player"))
        {
            if (puzzleSolvedText != null)
            {
                puzzleSolvedText.SetActive(true); // Show the text
            }
        }
    }
}