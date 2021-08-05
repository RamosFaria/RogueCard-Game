using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [TextArea(3,15)]
        [SerializeField] private string input;
        [SerializeField]
        private Font textFont;
        [SerializeField]
        private Color textColor;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBtLines;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay,delayBtLines, sound));
        }

    }

    
}

