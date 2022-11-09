using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posi : MonoBehaviour
{
    public GameObject Player;
    private Transform posiTr;
    
    // Start is called before the first frame update
    void Start()
    {
        posiTr = Player.GetComponent<Transform>();

     
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Player.transform.localPosition;
    }
}
