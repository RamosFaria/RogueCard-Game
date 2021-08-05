using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCard : MonoBehaviour
{
    public GameObject[] newCard;

    [SerializeField]
    private List<GameObject> cardsAvailable;

    [SerializeField]
    private GameObject[] cards;
    private void Start()
    {
        for(int i=0; i < cards.Length; i++)
        {
            
            if(!cards[i].GetComponent<Card>().isAvailable)
            {
                cardsAvailable.Add(cards[i]);
            }
        }

        int index;
        index = Random.Range(0, cardsAvailable.Count);
        for(int i=0; i++ < cardsAvailable.Count; i++)
        {
            newCard[i] = cardsAvailable[index];
        }
        
    }

}
