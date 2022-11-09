using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathC : MonoBehaviour
{
    public GameObject eyeball;
    // Start is called before the first frame update
    void Start()
    {
        GameObject eyeball = GameObject.Find("eyeballC");
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeball.activeSelf == false)
        {
            this.GetComponent<EnemyCtrlC>().enabled = false;
            this.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            this.GetComponent<EnemyCtrlC>().enabled = true;
            this.GetComponent<AudioSource>().enabled = true;
        }
    }
}

