using UnityEngine;

public class MainManu : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneChanger.Instance.LoadGameScene(1);
    }

    public void QuitGame()
    {
       Application.Quit();
    }

}
