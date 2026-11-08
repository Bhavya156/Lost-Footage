using UnityEngine;

public class BuildingBurner : MonoBehaviour
{

    Rigidbody otherRB;
    bool weBurning;

    [SerializeField] ParticleSystem burner1;
    [SerializeField] ParticleSystem burner2;
    [SerializeField] ParticleSystem burner3;
    [SerializeField] ParticleSystem burner4;
    [SerializeField] AudioSource audioSource;


    void OnTriggerEnter(Collider other)
    {
        if (!weBurning)
        {
            if (other.CompareTag("Arson"))
            {
                weBurning = true;

                GameManager.Instance.buildingBurning = true;
                GameManager.Instance.AddBurningBuilding(gameObject);

                Debug.Log("AAAAAAAAAAAAAAAAAAAAA WE BURNING Object");

                burner1.Play();
                burner2.Play();
                burner3.Play();
                burner4.Play();

                AudioManager.Instance.PlaySound(audioSource, AudioManager.Instance.fireEffect);
            }
        }
    }

    void Update()
    {

    }
}
