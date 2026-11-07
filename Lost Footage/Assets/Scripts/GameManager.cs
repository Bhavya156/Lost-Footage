using NUnit.Framework;
using System;
using TMPro.EditorUtilities;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    enum GameState { catPhoto, firePhoto, bankPhoto, ending }

    public static GameManager Instance { get; private set; }

    public bool catInTree;
    public GameObject targetCat;
    GameState gameState;

    public bool buildingBurning;
    public List<GameObject> burningBuildings;



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
                    }
                }
                break;
            case GameState.firePhoto:
                if (buildingBurning)
                {

                }
                break;
            case GameState.bankPhoto:

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
