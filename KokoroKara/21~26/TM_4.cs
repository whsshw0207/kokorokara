using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_4 : MonoBehaviour
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
        //Scene#23
        talkData.Add(10 + 5000, new string[]{"…。" ,
                                             "女房：もう一どだけ、はたをおりましょう。でももう、これっきりにしてくださいまし"});
        //Scene#23A
        talkData.Add(5000, new string[] { "Normal" });
        talkData.Add(100, new string[] { "盗み見ないと約束したから…。" });
        talkData.Add(200, new string[] { "盗み見よう。" });
        //quest Talk
         talkData.Add(30 + 5000, new string[]{"こんどは四日四晩織りつづけている…。"});
        talkData.Add(31 + 5000, new string[] { });

        //Scene#23B
        talkData.Add(90 + 6000, new string[] {"'まえよりもっとやつれた、いたいたしいふぜいだ。'",
            "さらに美しく、やわらかく、ほのかなかがやきをおびてさえ見える布地だ。"});

        //Scene#26
         talkData.Add(100 + 6000, new string[] { "となりの男：はて、どんな糸をつかうのかい。"+
        "あのようなうつくしさは、これまで、見たことはない。",
         "となりの男：うちの女房の織るもんでは、とてもそのような値にはならんが。", 
        "となりの男：あのたんものをとのさまがとても気にいられてな、このつぎは、もっと高くかうといっておられる。",
        "となりの男：その十倍にも、百倍にもうれるはず。どうだ、わしが口ききをつとめよう。もうけは山分け。一生、左うちわよ。",
        "それが、あれも、見たことがねぇんです。よめとのやくそくなもんで…",
        "となりの男：めおとでも見られねえとは、みょうなはなしだ。"});



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