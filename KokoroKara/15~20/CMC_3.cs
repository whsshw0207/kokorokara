using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CMC_3 : MonoBehaviour
{
    public Image CursorGameImage;
    public GameObject questObject;

    private Vector3 ScreenCenter;

    private float GageTimer;
    private int ButtonCount;

    GameObject scanObject;

    public GM_3 manager;
    public QM_3 questManager;

    public GameObject MenuSet;
    public GameObject Menu;

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
        if (questObject.activeSelf == false)
        {

            if (Physics.Raycast(ray, out rayHit, 100.0f, LayerMask.GetMask("Object")))
            {
                if (rayHit.collider != null)
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
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
        }

            if (Physics.Raycast(ray, out rayHit, 100.0f))
            {
                if (rayHit.collider.CompareTag("A"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        scanObject = rayHit.collider.gameObject;
                        manager.ChoiceA(scanObject);
                        GageTimer = 0;
                        manager.playAudioA();
                }

                }
                if (rayHit.collider.CompareTag("B"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        scanObject = rayHit.collider.gameObject;
                        manager.ChoiceB(scanObject);
                        GageTimer = 0;
                        manager.playAudioB();
                }

                }
            if (rayHit.collider.CompareTag("MenuSet"))
            {
                if (MenuSet.activeSelf == false)
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                if (GageTimer >= 1)
                {
                    MenuSet.SetActive(true);
                    Menu.SetActive(true);
                    GageTimer = 0;
                }
            }
        }
        else
            GageTimer = 0;
        if (MenuSet.activeSelf == true)
            if (Physics.Raycast(ray, out rayHit, 100.0f))
            {
                if (rayHit.collider.CompareTag("Exit"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        Application.Quit();
                    }
                }
                if (rayHit.collider.CompareTag("Save"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        manager.GameSave();
                        GageTimer = 0;
                    }
                }
                if (rayHit.collider.CompareTag("Load"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        manager.GameLoad();
                        GageTimer = 0;
                    }
                }
                if (rayHit.collider.CompareTag("MenuSet"))
                {
                    GageTimer += 1.0f / 2.0f * Time.deltaTime;
                    if (GageTimer >= 1)
                    {
                        MenuSet.SetActive(false);
                        Menu.SetActive(false);
                        GageTimer = 0;
                    }
                }
            }
            else
                GageTimer = 0;
    }
}

