using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SampleText
{
    //npc�� �̸� 
    public string npcName;
    // npc�� ������ �̹����� �̸�
    public string ImageName;
    //npc�� ��ȭ�� ����
    public string[] sentences;
}
public class SampleTextList
{
    public SampleText[] sampleText;
}