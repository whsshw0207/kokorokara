using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TY : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject EndCursor;
    //public bool isAnim;
    TextMeshProUGUI msgText;
    AudioSource audioSource;

    string targetMsg;

    int index;
    float interval;



    public void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();

    }
    public void SetMsg(string msg)
    {
        
            targetMsg = msg;
            EffectStart();
        

    }

    // Update is called once per frame
    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        //Start Animation
        interval = 1.0f / CharPerSeconds;
        Debug.Log(interval);

        //isAnim = true;

        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];


        //Sound
       // if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            //audioSource.Play();//

        index++;
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        //isAnim = false;
        EndCursor.SetActive(true);
    }
}
