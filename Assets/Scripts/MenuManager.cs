using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Image[] slots;

    private Transform deck;

    public List<GameObject> allCards;

    [SerializeField]
    private Transform CardSelection;

    [SerializeField]
    private Text text;

    private void Awake()
    {
        if (SaveManager.Instance.hasLoaded)
        {
            for (int i = 0; i < CardSelection.childCount; i++)
            {
                Debug.Log(CardSelection.transform.GetChild(i).GetComponent<CardSelectionMenu>().cardReference.name);
                Debug.Log(SaveManager.Instance.activeSave.newCardName);
                if(SaveManager.Instance.activeSave.newCardName.Length != 0)
                {
                    if (SaveManager.Instance.activeSave.newCardName[i] == CardSelection.transform.GetChild(i).GetComponent<CardSelectionMenu>().cardReference.name)
                    {
                        
                        CardSelection.GetChild(i).GetComponent<CardSelectionMenu>().cardReference.GetComponent<Card>().isAvailable = true;
                    }
                }
                else
                {
                    return;
                }


            }


        }
    }

    void Start()
    {
        
        deck = GameObject.Find("SelectedCards").transform;
        Time.timeScale = 1;

    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            
            if(hit.collider!= null && hit.collider.gameObject.CompareTag("SelectCard"))
            {
                GameObject obj = hit.collider.GetComponent<CardSelectionMenu>().cardReference;
                GameObject selectedCard = Instantiate(obj, transform.position, Quaternion.identity) as GameObject;
                
                selectedCard.transform.SetParent(deck);
                selectedCard.SetActive(false);
            }

        }

        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("SelectCard"))
            {
                GameObject selectedCard = hit.collider.GetComponent<CardSelectionMenu>().cardReference;
                //selectedCard.name
                //SceneManager.MoveGameObjectToScene(selectedCard, SceneManager.GetActiveScene());
            }
        }


    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Play()
    {
        if (deck.childCount <=2)
        {
            text.gameObject.SetActive(true);
            Invoke("Desapear",2f);
        }
        else
        {
            GameObject.FindObjectOfType<SceneLoading>().LoadLevel(3);
        }
        
        
    }

    public void OpenDeckSelection()
    {
        if (SaveManager.Instance.hasLoaded)
        {
            for (int i = 0; i < CardSelection.childCount; i++)
            {
                if(SaveManager.Instance.activeSave.newCardName.Length != 0)
                {
                    if (SaveManager.Instance.activeSave.newCardName[i] == CardSelection.transform.GetChild(i).GetComponent<CardSelectionMenu>().cardReference.name)
                    {
                        Debug.Log("a");
                        CardSelection.GetChild(i).GetComponent<CardSelectionMenu>().cardReference.GetComponent<Card>().isAvailable = true;
                    }
                }
            }

            CardSelection = GameObject.Find("Cards").transform;

            for (int i = 0; i < CardSelection.childCount; i++)
            {

                GameObject Card = CardSelection.GetChild(i).GetComponent<CardSelectionMenu>().cardReference;

                if (Card.GetComponent<Card>().isAvailable == true)
                {
                    CardSelection.GetChild(i).gameObject.SetActive(true);
                }


            }
        }


    }

    private void Desapear()
    {
        text.gameObject.SetActive(false);
    }


}
