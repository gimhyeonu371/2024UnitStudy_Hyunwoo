using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SampleText
{
    //npc의 이름 
    public string npcName;
    // npc의 아이콘 이미지의 이름
    public string ImageName;
    //npc가 대화할 문장
    public string[] sentences;
}
public class SampleTextList
{
    public SampleText[] sampleText;
}