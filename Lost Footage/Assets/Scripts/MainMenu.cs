using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{

    [SerializeField] private SceneChanger sceneChanger;

    public void StartGame()
    {

        sceneChanger.LoadGameScene("Intro");

    }

    public void QuitGame()
    {
       Application.Quit();
    }

}
