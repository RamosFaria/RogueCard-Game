using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        [SerializeField]
        private GameObject dialoguetrigger;

        private Animator anim;

        private void Awake()
        {
            
            anim = GetComponent<Animator>();
            //StartCoroutine(dialogueSequence());
        }

        private void Start()
        {
            anim.Play("DialogueBoxAnimation");
            
        }

        private IEnumerator dialogueSequence()
        {
            for(int i =0; i<transform.childCount;i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            Destroy(dialoguetrigger);
            GameObject.FindObjectOfType<Character>().dialogueActive = false;
            gameObject.SetActive(false);

        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
             
        }


        public void Ended()
        {
            StartCoroutine(dialogueSequence());
        }

    }
}

