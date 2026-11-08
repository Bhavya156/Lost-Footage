using UnityEngine;

public class MainManu : MonoBehaviour
{
    public void StartGame()
    {
        SceneChanger.Instance.LoadGameScene(1);
    }

    public void QuitGame()
    {
       Application.Quit();
    }

}
