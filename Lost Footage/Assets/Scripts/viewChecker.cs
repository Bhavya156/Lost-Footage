using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class viewChecker : MonoBehaviour
{
    public List<Targets> targetsToCheck = new List<Targets>();
    // public int articleNo;
    // [SerializeField] private GameObject target;
    [SerializeField] private Camera camera;

    void Update()
    {
        CheckTargetByArticle(1);
    }

    void CheckTargetByArticle(int articleNo)
    {
        switch(articleNo)
        {
            case 1:
                // element 0 from targetObjects list and random object from element 1 to 5
                GameObject[] article1Obs = ReturnTargetObjects(0);

                if (article1Obs != null)
                {
                    // if (article1Obs[0] && )
                    Debug.Log("Article 1 is visible");
                }
                break;
            case 2:
                // Building on element 0 on targetObjects and fire on element 1
                GameObject[] article2Obs = ReturnTargetObjects(1);

                if (article2Obs != null && IsVisible(article2Obs))
                {
                    Debug.Log("Article 2 is visible");
                }
                break;
            case 3:
                // Bank robbery
                GameObject[] article3Obs = ReturnTargetObjects(2);
                if (article3Obs != null && IsVisible(article3Obs))
                {
                    Debug.Log("Article 3 is visible");
                }
                break;
            default:
                break;
        }
    }

    GameObject[] ReturnTargetObjects(int index)
    {
        GameObject[] targObj = targetsToCheck[index].targetObjects.ToArray();

        return targObj;
    }

    // private bool IsVisible()
    // {
    //     Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
    //     // return planes.All(Plane => Plane.GetDistanceToPoint(target.transform.position) >= 0);
    //     return false;
    // }

    private bool IsVisible(GameObject[] targetObjects)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        foreach (GameObject obj in targetObjects)
        {
            if (obj == null || !obj.activeInHierarchy)
                return false;

            Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

            bool objectVisible = false;

            foreach (Renderer rend in renderers)
            {
                if (GeometryUtility.TestPlanesAABB(planes, rend.bounds))
                {
                    objectVisible = true;
                    break;
                }
            }

            if (!objectVisible)
            {
                Debug.Log("Object not visible");
                return false;
            }
        }

        return true;
    }
}


[Serializable]
public class Targets
{
    public int articleNo;
    public List<GameObject> targetObjects = new List<GameObject>();
}