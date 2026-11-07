using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadGameScene(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
    }

}
