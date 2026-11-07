using UnityEngine;

public class GasTanker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
