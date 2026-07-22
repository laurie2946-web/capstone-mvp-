using UnityEngine;

public class SimpleVRButton : MonoBehaviour
{
    [Header("Target Screen to Pop Up")]
    public GameObject screenToActivate;

    private bool hasBeenPressed = false;

    private void Start()
    {
        // Ensure screen starts hidden
        if (screenToActivate != null)
        {
            screenToActivate.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Triggers when touched by a VR Hand or Player
        if (!hasBeenPressed && (other.CompareTag("Hand") || other.CompareTag("Player")))
        {
            hasBeenPressed = true;

            if (screenToActivate != null)
            {
                screenToActivate.SetActive(true);
            }
        }
    }
}
