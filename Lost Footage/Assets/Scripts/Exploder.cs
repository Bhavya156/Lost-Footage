using UnityEngine;

public class Exploder : MonoBehaviour
{

    public ParticleSystem ps1;
    public ParticleSystem ps2;

    float timer;
    public float totalTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps1.Play();
        ps2.Play();
        gameObject.AddComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= totalTime) Destroy(gameObject);
    }
}
