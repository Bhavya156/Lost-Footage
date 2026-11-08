using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public enum GameState { catPhoto, firePhoto, bankPhoto, ending }

    public static GameManager Instance { get; private set; }

    public bool catInTree;
    public GameObject targetCat;
    public GameState gameState;

    public bool buildingBurning;
    public List<GameObject> burningBuildings;

    public bool bankBroken;
    public GameObject bank;

    public bool triggerTruck;
    public bool triggerPlane;



    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

    }


    void Update()
    {
        
    }

    public void TakenPhoto(Camera cameraTakingPhoto)
    {
        switch (gameState)
        {
            case GameState.catPhoto:
                if (catInTree)
                {
                    if (checkPhoto(targetCat, cameraTakingPhoto))
                    {
                        gameState = GameState.firePhoto;
                        triggerTruck = true;
                        //PUT TRANSITION HERE
                    }
                }
                break;
            case GameState.firePhoto:
                if (buildingBurning)
                {
                    foreach(GameObject building in burningBuildings)
                    {
                        if (checkPhoto(building, cameraTakingPhoto))
                        {
                            gameState = GameState.bankPhoto;
                            triggerPlane = true;
                            //PUT TRANSITION HERE
                            break;
                        }
                    }
                }
                break;
            case GameState.bankPhoto:
                if (bankBroken)
                {
                    if (checkPhoto(bank, cameraTakingPhoto))
                    {
                        gameState = GameState.ending;
                        //PUT TRANSITION HERE
                        break;
                    }
                }
                break;
        }
    }

    public bool checkPhoto(GameObject targetObject, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        Collider collider = targetObject.GetComponent<Collider>();

        if (GeometryUtility.TestPlanesAABB(planes, collider.bounds))
        {
            Debug.Log("in view");
            return true;
        }
        Debug.Log("not in view");
        return false;
    }

    public void AddBurningBuilding(GameObject burningBuilding)
    {
        burningBuildings.Add(burningBuilding);
    }
}
