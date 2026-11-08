using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Slider loadingBar;
    public static SceneChanger Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public IEnumerator LoadNextLevel()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(2);
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