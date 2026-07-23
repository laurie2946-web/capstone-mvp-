using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject textObj;
    public bool triggerOnce = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.GetComponentInParent<Unity.XR.CoreUtils.XROrigin>() != null)
        {
            textObj.SetActive(true);
        }

        if(triggerOnce)
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}
