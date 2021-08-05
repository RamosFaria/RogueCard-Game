using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private Animator characterAnim = null;

    public List<GameObject> deck;
    public List<GameObject> handDeck;

    private float time;

    private Transform selectedDeck;
    [SerializeField]
    private Transform[] cardsSpawn;

    private GameObject usedCard;
    private GameObject newCard;

    private Animator anim;

    void Start()
    {
        selectedDeck = GameObject.FindObjectOfType<SelectedCards>().transform;
        

        for(int i =0; i < selectedDeck.childCount; i++)
        {
            deck.Add(selectedDeck.GetChild(i).gameObject);
        }

        for(int i = 0; i <3; i++)
        {
            GameObject obj = deck[Random.Range(0, deck.Count)];
            handDeck.Add(obj);
            GameObject instantiatedObj = Instantiate(obj, cardsSpawn[i]);
            instantiatedObj.SetActive(true);
            switch (i)
            {
                case 0:
                    instantiatedObj.tag = "J";
                    
                    break;
                case 1:
                    instantiatedObj.tag = "K";
                    break;
                case 2:
                    instantiatedObj.tag = "L";
                    break;
            }

        }
        anim = GameObject.FindObjectOfType<Character>().GetComponent<Animator>();
    }
    
    void Update()
    {
        time += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.J) && time >=1f)
        {
            
            UseCard("J", 0);
            time = 0f;
        }

        if (Input.GetKeyDown(KeyCode.K) && time >= 1f)
        {
            
            UseCard("K", 1);
            time = 0f;
        }

        if (Input.GetKeyDown(KeyCode.L) && time >= 1f)
        {
            
            UseCard("L", 2);
            time = 0f;
        }

    }
    public void UseCard(string tag, int pos)
    {
        usedCard = GameObject.FindGameObjectWithTag(tag);
        if (usedCard.GetComponent<Card>().canUse)
        {
            characterAnim.Play("CharacterAttack");
            usedCard.GetComponent<Card>().UseCard();
            usedCard.GetComponent<Dissolve>().isDissolving = true;
            newCard = deck[Random.Range(0, deck.Count)];
            GameObject obj = Instantiate(newCard, cardsSpawn[pos]) as GameObject;
            obj.SetActive(true);
            obj.tag = tag;
            obj.layer = 9;
        }
        else
        {
            return;
        }
        

    }
}
