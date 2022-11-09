using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questtActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;
    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestData("talk with villager"
                                         , new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("find coin for Ludo"
                                         , new int[] {200, 2000}));
        questList.Add(30, new QuestData("Quest30"
                                         , new int[] {2000}));
        questList.Add(40, new QuestData("Quest40"
                                        , new int[] { 200,2000}));
        questList.Add(50, new QuestData("Quest50"
                                , new int[] { 2000 }));
        questList.Add(60, new QuestData("Quest60"
                                        , new int[] { 300, 2000 }));
       
       
    }
    public int GetQuestTalkIndex(int id)
    {
        return questId + questtActionIndex;
    }
    public string CheckQuest(int id)
    {
        

        if (id == questList[questId].npcId[questtActionIndex])
            questtActionIndex++;  //퀘스트 번호를 올리기(퀘스트 별 대화 순서를 올리는 것 퀘스트 아님)

        ControlObject();

        if (questtActionIndex == questList[questId].npcId.Length)
        { NextQuest(); }
 
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questtActionIndex = 0;
        
        switch (questId)
        {
     
            case 40:
                SceneManager.LoadScene("Scene2");
                break;
            case 60:
                SceneManager.LoadScene("Scene2");
                break;
        }


    }

    public void NextQuestA()
    {
        questId += 10;
        questtActionIndex = 0;
        questObject[0].SetActive(false);


    }
    public void NextQuestB()
    {
        questId += 30;
        questtActionIndex = 0;
        questObject[0].SetActive(false);
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questtActionIndex == questList[questId].npcId.Length)
                    questObject[0].SetActive(true);
                break;

                }
    }
    
}