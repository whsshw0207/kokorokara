using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_2 : MonoBehaviour
{
    public CMC_2 Camera2;
    public TM_2 talkManager;
    public QM_2 questManager;
    public Animator talkPanel;
    public TY talk;

    public GameObject MenuSet;
    public GameObject Menu;

    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public AudioClip[] sound;

    AudioSource audioSource;
    public int Count;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Count = 0;
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow", isAction);
        audioSource.Stop();
        playAudio();
        Count += 1;

    }

    public void ChoiceA(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        questManager.NextQuestA();
        Talk(objData.id, objData.isNpc);
        talkPanel.SetBool("isShow", isAction);

    }
    public void ChoiceB(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        questManager.NextQuestB();
        Talk(objData.id, objData.isNpc);
        talkPanel.SetBool("isShow", isAction);

    }


    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";
        //Set Talk Data
        //if (talk.isAnim)
        //{
        //    talk.SetMsg("");
        //   return;
        //}
       // else
       // {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
//}

        //End Talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }
        //Continue Talk
        if (isNpc)
        {
            talk.SetMsg(talkData);
        }
        else
        {
            talk.SetMsg(talkData);
        }

        isAction = true;
        talkIndex++;
    }
    public void playAudio()
    {
        audioSource.PlayOneShot(sound[Count]);
    }
    public void playAudioA()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;
        switch (buildIndex)
        {
            case 10:
                Count += 0;
                break;


        }
    }
    public void playAudioB()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;
        switch (buildIndex)
        {
            case 10:
                Count += 2;
                break;


        }

    }
    public void GameSave()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.Save();

        MenuSet.SetActive(false);
        Menu.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("QuestId"))
            return;

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));



        questManager.ControlObject();

    }

}
