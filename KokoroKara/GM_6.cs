using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_6 : MonoBehaviour
{
    public CMC_6 Camera1;
    public TM_6 talkManager;
    public QM_6 questManager;
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

    
    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";
        //Set Talk Data
        //if (talk.isAnim)
        //{
        //     talk.SetMsg("");
        //    return;
        //}
        // else
        // {
        questTalkIndex = questManager.GetQuestTalkIndex(id);
        talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        // }

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
            case 3:
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
            case 3:
                Count += 1;
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
