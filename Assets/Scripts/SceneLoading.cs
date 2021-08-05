using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private GameObject LoadingScreen;

    private AsyncOperation sceneLoad;

    private Image progressBar;

    void Start()
    {
        
        
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsyncOperation(sceneIndex));
    }

    private IEnumerator LoadSceneAsyncOperation(int SceneIndex)
    {
        
        LoadingScreen.SetActive(true);
        progressBar = GameObject.Find("ProgressBar").GetComponent<Image>();
        if (GameObject.FindObjectOfType<SaveManager>().activeSave.deaths < 1 && SceneManager.GetActiveScene().buildIndex <1)
        {
            sceneLoad = SceneManager.LoadSceneAsync(1);
        }
        else
        {
            sceneLoad = SceneManager.LoadSceneAsync(SceneIndex);
        }
        

        while(sceneLoad.progress < 1)
        {
            progressBar.fillAmount = sceneLoad.progress;
            yield return new WaitForEndOfFrame();
        }

        
    }




    
    void Update()
    {
        
    }
}
