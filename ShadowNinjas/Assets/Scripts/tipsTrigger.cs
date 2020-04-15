using UnityEngine;

public class tipsTrigger : MonoBehaviour
{
    public GameObject tips;

    // Display tips while in the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tips.SetActive(true);
        }
    }
    // Disable tips while leaving the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tips.SetActive(false);
        }
    }
}
