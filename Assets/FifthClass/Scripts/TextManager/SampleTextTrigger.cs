using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTextTrigger : MonoBehaviour
{
    private void Start()
    {
        TriggerText(sampleText);
    }

    private void TriggerText(SampleText sampleText)
    {
        throw new NotImplementedException();
    }

    public SampleText[] sampleText;

    public void TriggerText(SampleText[] sampleTexts)
    {
        FindObjectOfType<SampleTextmanager>().StartText(sampleTexts);
    }
}
