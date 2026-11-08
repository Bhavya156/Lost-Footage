using UnityEngine;

public class JetMover : MonoBehaviour
{

    [SerializeField] Transform planeMesh;
    [SerializeField] GameObject crashedPlaneMesh;
    Vector3 initPos;
    [SerializeField] Vector3 distToTravel;
    [SerializeField] float travelTime;
    [SerializeField] float explosionTime;
    float timer;
    bool isTraveling;
    bool hasTraveled;

    [SerializeField] ParticleSystem explosion1;
    [SerializeField] ParticleSystem explosion2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPos = planeMesh.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTraveled)
        {
            if (GameManager.Instance.triggerPlane)
            {
                GameManager.Instance.triggerPlane = false;
                isTraveling = true;
                planeMesh.gameObject.SetActive(true);
            }

            if (isTraveling)
            {
                timer += Time.deltaTime;
                planeMesh.position = initPos + (distToTravel * (timer / travelTime));
                if (timer >= travelTime)
                {
                    planeMesh.position = initPos + distToTravel;
                    isTraveling = false;
                    hasTraveled = true;
                }

                if(timer >= explosionTime)
                {
                    explosion1.Play();
                    explosion2.Play();
                    explosionTime *= 2;
                    crashedPlaneMesh.gameObject.SetActive(true);
                }
            }
        }
    }
}