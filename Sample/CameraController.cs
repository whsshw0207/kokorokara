using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CameraController : MonoBehaviour
{
    public Image CursorGameImage;

    private Vector3 ScreenCenter;

    private float GageTimer;
    private int ButtonCount;

    GameObject scanObject;

    public GameManager manager;
    public QuestManager questManager;
   


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

        if (Physics.Raycast(ray, out rayHit, 100.0f, LayerMask.GetMask("Object")))
        {
            if (rayHit.collider != null)
            {
                GageTimer += 0.5f / 1.0f * Time.deltaTime;
                if (GageTimer >= 1)
                {
                    scanObject = rayHit.collider.gameObject;
                    manager.Action(scanObject);
                    GageTimer = 0;
                }
            }
            else
                scanObject = null;
        }
      

        if (Physics.Raycast(ray, out rayHit, 100.0f))
        {
            if (rayHit.collider.CompareTag("A"))
            {
                GageTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GageTimer >= 1)
                {
                    scanObject = rayHit.collider.gameObject;
                    manager.ChoiceA(scanObject);
                    GageTimer = 0;
                }

            }
            if (rayHit.collider.CompareTag("B"))
            {
                GageTimer += 1.0f / 3.0f * Time.deltaTime;
                if (GageTimer >= 1)
                {
                    scanObject = rayHit.collider.gameObject;
                    manager.ChoiceB(scanObject);
                    GageTimer = 0;
                }

            }
        }
        else
            GageTimer = 0;

    }
}

