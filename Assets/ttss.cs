using Meta.WitAi.TTS.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttss : MonoBehaviour
{
    private TTSSpeaker speaker;
    // Start is called before the first frame update
    void Start()
    {
        string speech = "hello"??"";
        if (speech != null)
        {
            speaker.Speak(speech);
            Debug.Log(speech);
        }
        else
        {
            Debug.Log("WTF");
        }
        Debug.Log("REached line");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
