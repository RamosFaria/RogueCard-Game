using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCard : MonoBehaviour
{
    [SerializeField]
    private GameObject NewCardMessage = null;

    private GameObject newCard;

    private float time;

    private void Update()
    {
        if(NewCardMessage.activeInHierarchy)
        {
            time += Time.deltaTime;
            if(time > 5f)
            {
                NewCardMessage.SetActive(false);
                time = 0;
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Drop"))
        {
            NewCardMessage.SetActive(true);

            for(int i=0; i< collision.gameObject.GetComponent<NewCard>().newCard.Length;i++)
            {
                string name = collision.gameObject.GetComponent<NewCard>().newCard[i].name;
                SaveManager.Instance.activeSave.newCardName[i] = name;
            }
            SaveManager.Instance.Save();
            Destroy(collision.gameObject);
        }
    }
}
