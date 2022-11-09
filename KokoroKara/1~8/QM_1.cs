using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QM_1 : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    public GM_1 manager;
    Dictionary<int, QuestData> questList;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
       //Scene #1
       questList.Add(10, new QuestData("Talk with mosaku"
                                         , new int[] {1000}));
        questList.Add(20, new QuestData("choice"
                                         , new int[] { 200, 1000 }));
        questList.Add(30, new QuestData("Quest30"
                                         , new int[] { 1000 }));
        questList.Add(40, new QuestData("Quest40"
                                        , new int[] { 200, 1000 }));
        questList.Add(50, new QuestData("Quest50"
                                , new int[] { 1000 }));
        questList.Add(60, new QuestData("Quest60"
                                , new int[] { 1000 })); 
         //Scene #3
        questList.Add(70, new QuestData("Talk with Yukionna"
                                , new int[] { 2000 }));
        questList.Add(80, new QuestData("choice"
                                        , new int[] { 300, 2000 }));
        questList.Add(90, new QuestData("Quest90"
                                         , new int[] { 2000 }));
        questList.Add(100, new QuestData("Quest100"
                                        , new int[] { 300,2000 }));
        questList.Add(110, new QuestData("Quest110"
                                , new int[] { 2000 }));
        questList.Add(120, new QuestData("Quest120"
                                , new int[] { 2000 }));
        //Scene #5
        questList.Add(130, new QuestData("Quest120"
                                , new int[] { 3000 }));
        //Scene #7
        questList.Add(140, new QuestData("Quest120"
                               , new int[] {3000}));
        questList.Add(150, new QuestData("Quest120"
                               , new int[] { 3000 }));
    }
    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }
    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;  

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length)
        { NextQuest(); }

        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
        switch (questId)
        {

            case 40:
                
                LoadScene();
                break;
            case 60:
                
                LoadScene();
                break;
            case 100:
                manager.Count = 0;
                LoadScene();
                break;
            case 120:
                manager.Count = 0;
                LoadScene();
                break;
            case 140:
                manager.Count = 0;
                LoadScene();
                break;
            case 150:
                manager.Count = 0;
                LoadScene();
                break;

        }
    }

    private void LoadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void NextQuestA()
    {
        questId += 10;
        questActionIndex = 0;
        questObject[0].SetActive(false);
    }
    public void NextQuestB()
    {
        questId += 30;
        questActionIndex = 0;
        questObject[0].SetActive(false);
    }

    public void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == questList[questId].npcId.Length)
                    questObject[0].SetActive(true);
                break;
            case 70:
                if (questActionIndex == questList[questId].npcId.Length)
                    questObject[0].SetActive(true);
                break;
        }
    }
}