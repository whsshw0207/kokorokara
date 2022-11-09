using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeathA : MonoBehaviour
{
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
            this.GetComponent<EnemyCtrlA>().enabled = false;
            this.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            this.GetComponent<EnemyCtrlA>().enabled = true;
            this.GetComponent<AudioSource>().enabled = true;
        }
     }
}

