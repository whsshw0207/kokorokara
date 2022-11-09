using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Move : MonoBehaviour
{
    AudioSource audioSource;
    public float Speed = 2f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        MoveCtrl();
    }

    void MoveCtrl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
        if (Input.GetMouseButtonDown(1))
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }


        if (Input.GetMouseButton(0))
        {
            this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            audioSource.Play();
        }
        if (Input.GetMouseButton(1))
        {
            this.transform.Translate(Vector3.back * Speed * Time.deltaTime);
            audioSource.Play();
        }

    }
}
