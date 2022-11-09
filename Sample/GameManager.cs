using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel; 
    public TypeEffect talk;

    public GameObject scanObject;
    public  bool isAction;
    public int talkIndex;

   

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow", isAction);

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
        if (talk.isAnim) { 
            talk.SetMsg("");
            return;
        }  
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

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
            talk.SetMsg(talkData);        }
        else{
            talk.SetMsg(talkData);
        }

        isAction = true;
        talkIndex++;
    }
}
