using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCtrlC : MonoBehaviour
{
    AudioSource audioSource;
    public Transform[] points;

    public int nextIdx = 1;

    public float speed = 10.0f;
    public float damping = 5.0f;

    private Transform tr;
    private Transform playerTr;

    private Vector3 movePos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        tr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        points = GameObject.Find("WayPointGroupC").GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        float dist = Vector3.Distance(tr.position, playerTr.position);

        if (dist <= 13.0f)
        {
            movePos = playerTr.position;

            if (dist <= 9f)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            { movePos = playerTr.position; }

        }
        else
        {
            movePos = points[nextIdx].position;
        }

        Quaternion rot = Quaternion.LookRotation(movePos - tr.position);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "WAY_POINT_C")
        {
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
        }
    }




}
