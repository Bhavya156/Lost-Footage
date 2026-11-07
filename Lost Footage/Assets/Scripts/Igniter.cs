using UnityEngine;

public class Igniter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flammable"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
