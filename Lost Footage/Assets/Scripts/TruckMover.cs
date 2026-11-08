using UnityEngine;

public class TruckMover : MonoBehaviour
{

    Vector3 initPos;
    [SerializeField] Vector3 distToTravel;
    [SerializeField] float travelTime;
    float timer;
    bool isTraveling;
    bool hasTraveled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTraveled)
        {
            if (GameManager.Instance.triggerTruck)
            {
                GameManager.Instance.triggerTruck = false;
                isTraveling = true;
            }

            if (isTraveling)
            {
                timer += Time.deltaTime;
                transform.position = initPos + (distToTravel * (timer / travelTime));
                if(timer >= travelTime)
                {
                    transform.position = initPos + distToTravel;
                    isTraveling = false;
                    hasTraveled = true;
                }
            }
        }
    }
}
