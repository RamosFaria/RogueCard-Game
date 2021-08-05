using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int index;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if(collision.gameObject.CompareTag("Player"))
        {
            
            if(FindObjectOfType<Boss>() == null)
            {
                GameObject.FindObjectOfType<SceneLoading>().LoadLevel(index);
            }
            else
            {
                return;
            }
                
            
            /*
            Debug.Log(SceneManager.sceneCountInBuildSettings + 1);
            if(SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings )
            {
                GameObject.FindObjectOfType<Manager>().EndGame();
            }
            else
            {
                GameObject.FindObjectOfType<SceneLoading>().LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
            */
            


            /*
            if(SceneManager.GetActiveScene().buildIndex < 2)
            {
                int index = Random.Range(2, 4);
                GameObject.FindObjectOfType<SceneLoading>().LoadLevel(index);
            }
            else if(SceneManager.GetActiveScene().buildIndex < 4)
            {
                int index = Random.Range(5, 7);
                GameObject.FindObjectOfType<SceneLoading>().LoadLevel(index);
            }
            */
        }
    }
}
