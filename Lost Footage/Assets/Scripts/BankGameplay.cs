using UnityEngine;

public class BankGameplay : MonoBehaviour
{

    public GameObject bank;
    public GameObject bankBroken;

    bool alreadyBroken;

    public ParticleSystem explosion1;
    public ParticleSystem explosion2;

    public float requiredVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!alreadyBroken)
        {
            if (other.CompareTag("Vehicle"))
            {
                Debug.Log("WOAHHHHHH SOEMTHING HERE");
                Debug.Log(other.GetComponent<Rigidbody>().linearVelocity.magnitude);
                if (other.GetComponent<Rigidbody>().linearVelocity.magnitude >= requiredVelocity) ExplodeBank();
            }
        }
    }

    void ExplodeBank()
    {
        bank.SetActive(false);
        bankBroken.SetActive(true);

        alreadyBroken = true;

        explosion1.Play();
        explosion2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
