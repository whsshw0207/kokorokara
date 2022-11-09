using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SolvedSoundA : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject eyeball;
    // Start is called before the first frame update
    void Start()
    {
        GameObject eyeball = GameObject.Find("eyeballA");
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeball.activeSelf == false)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
 
        }
        else
        {
            this.GetComponent<AudioSource>().enabled = true;

        }
    }
}
