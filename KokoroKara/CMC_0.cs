using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CMC_0 : MonoBehaviour
{
    public Image CursorGameImage;

    private Vector3 ScreenCenter;

    private float GageTimer;
    private int ButtonCount;

    GameObject scanObject;

    public GameObject videoHandle;



    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        RaycastHit rayHit;
        CursorGameImage.fillAmount = GageTimer;
        if (videoHandle.activeSelf == false)
        { 
            if (Physics.Raycast(ray, out rayHit, 100.0f))
            {
                if (rayHit.collider.CompareTag("next"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        LoadScene();
                        GageTimer = 0;
                    }

                }
                if (rayHit.collider.CompareTag("final"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        SceneManager.LoadScene("Final");
                        GageTimer = 0;
                    }

                }

            }
            else
                GageTimer = 0;
        }
    }

    private void LoadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }
}

