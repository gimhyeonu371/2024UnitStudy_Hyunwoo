using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SampleTextmanager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameText;
    public Image npcIcon;

    public Queue<string> stringQueue;
    public string iconID;
    public void Start()
    {
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{iconID}");

    }
    public void StartText(SampleText[] sampleTexts)
    {
        nameText.text = sampleTexts[0].npcName;
        textComponent.text = sampleTexts[0].sentences[0];

        //SampleText sampleText = sampleTexts
        //foreach (string sentence in SampleText.sentences)
        //{

        //    stringQueue.Enqueue(sentecne);
        //}
    }
   

    public void DisplayNextScens()
    {
        Debug.Log("버튼 호출!");
    }
 


}

