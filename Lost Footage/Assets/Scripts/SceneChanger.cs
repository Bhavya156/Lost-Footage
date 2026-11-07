using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Slider loadingBar;
    public void LoadGameScene(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public IEnumerator LoadNextLevel()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(1);
        loadLevel.allowSceneActivation = false;

        while (!loadLevel.isDone)
        {
            loadingBar.value =  Mathf.Clamp01(loadLevel.progress / .9f);
            
            if(loadLevel.progress >= 0.9f)
            {
                yield return new WaitForSeconds(3f);
                loadLevel.allowSceneActivation = true;
            }
            
            yield return null;
        }


    }

}