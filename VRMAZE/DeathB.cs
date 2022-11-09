using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathB : MonoBehaviour
{
    public GameObject eyeball;
    // Start is called before the first frame update
    void Start()
    {
        GameObject eyeball = GameObject.Find("eyeballB");
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeball.activeSelf == false)
        {
            this.GetComponent<EnemyCtrlB>().enabled = false;
            this.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            this.GetComponent<EnemyCtrlB>().enabled = true;
            this.GetComponent<AudioSource>().enabled = true;
        }
    }
}

