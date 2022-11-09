using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "Hello", "You are new here" });
        talkData.Add(2000, new string[] { "Hey", "Bye" });
        talkData.Add(100, new string[] { "This is a box" });
        talkData.Add(200, new string[] { "This is a box" });
        //quest Talk
        talkData.Add(10 + 1000, new string[]{"Hi",
                                            "There is a surprising story about this lake",
                                            "Ludo will tell you."});
        talkData.Add(11 + 1000, new string[] { "Ludo is over there" });
        talkData.Add(11 + 2000, new string[]{"Hey",
                                            "I will tell you everything"});

       
        talkData.Add(20 + 200, new string[] { "Find coin" });
        talkData.Add(21 + 2000, new string[] { "adkadkihas", "adkadkihas" });
     
        talkData.Add(30 + 200, new string[] { "Quest30" });
        talkData.Add(30 + 2000, new string[] { "Quest30=1", "Quest30=2" });

      
        talkData.Add(50 + 300, new string[] { "Quest50" });
        talkData.Add(50 + 2000, new string[] { "Quest51", "Quest52" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

    }

}