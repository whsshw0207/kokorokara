using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QM_4 : MonoBehaviour
{
    public int questId;
    public int questtActionIndex;
    public GameObject[] questObject;
    public GM_4 manager;


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
        //Scene #23
        questList.Add(10, new QuestData("Talk with mosaku"
                                          , new int[] { 5000 }));
        questList.Add(20, new QuestData("choice"
                                         , new int[] {  5000 }));
        //Scene #23A
        questList.Add(30, new QuestData("Quest30"
                                         , new int[] {5000 }));
        questList.Add(40, new QuestData("Quest30"
                                        , new int[] { 200, 5000 }));
        questList.Add(50, new QuestData("Quest50"
                                , new int[] {  5000 }));
        questList.Add(60, new QuestData("Quest60"
                                , new int[] { 200,5000 }));
        questList.Add(70, new QuestData("Quest70"
                                , new int[] { 5000 }));
        questList.Add(80, new QuestData("Quest120"
                                , new int[] { 5000 }));
        //Scene #23B
        questList.Add(90, new QuestData("Quest30"
                                         , new int[] { 6000 }));
        //Scene #26
        questList.Add(100, new QuestData("Quest30"
                                        , new int[] { 6000 }));
        questList.Add(110, new QuestData("Quest30"
                                        , new int[] { 6000 }));




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
            case 20:
                LoadScene();
                break;
            //23A
            case 60:
                LoadScene();
                break;
            case 80:
                SceneManager.LoadScene("EndingE");
                break;

            //23B
            case 100:
                LoadScene();
                break;
            //26
            case 110:
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
        questtActionIndex = 0;
        questObject[0].SetActive(false);


    }
    public void NextQuestB()
    {
        questId += 30;
        questtActionIndex = 0;
        questObject[0].SetActive(false);
    }

   　public void ControlObject()
    {
        switch (questId)
        {
            case 30:
                if (questtActionIndex == questList[questId].npcId.Length)
                    questObject[0].SetActive(true);
                break;
          



        }
    }

}