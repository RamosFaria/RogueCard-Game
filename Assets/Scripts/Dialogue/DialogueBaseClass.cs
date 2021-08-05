using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }
        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, float delayBtLines, AudioClip sound  )
        {
            textHolder.font = textFont;
            textHolder.color = textColor;
            for (int i=0; i<input.Length; i++)
            {
                textHolder.text += input[i];
                //SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            finished = true;
        }
    }

}
