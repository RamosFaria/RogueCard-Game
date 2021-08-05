using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuInGame; 

    [SerializeField]
    private GameObject deathScreen;

    public static Manager instance;

    [SerializeField]
    private GameObject endGame;

    public bool bossIsAlive;

    

    private void Start()
    {
        ResumeGame();
        Character character = GameObject.Find("Character").GetComponent<Character>();
        character.enabled = true;

    }


    public void DeathEvent()
    {
        
        Pause();
        deathScreen.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex > 0)
        {
            
            if (menuInGame.activeInHierarchy)
            {
                ResumeGame();
                menuInGame.SetActive(false);
            }
            else
            {
                Pause();
                menuInGame.SetActive(true);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        GameObject.FindObjectOfType<SceneLoading>().LoadLevel(2);
        SaveManager.Instance.Save();
    }

    public void MainMenu()
    {
        GameObject.FindObjectOfType<SceneLoading>().LoadLevel(0);
        SaveManager.Instance.Save();
    }

    public void EndGame()
    {

        endGame.SetActive(true);
        Pause();
    }


}
