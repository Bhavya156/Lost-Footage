using System.Linq;
using UnityEngine;

public class viewChecker : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private Camera camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible())
        {
            Debug.Log("heheheha");
        }
    }

    private bool isVisible()
    {
        Plane[]planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return planes.All(Plane => Plane.GetDistanceToPoint(target.transform.position) >= 0);
    }
}
