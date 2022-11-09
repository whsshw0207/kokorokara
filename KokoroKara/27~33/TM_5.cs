using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_5 : MonoBehaviour
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

        //Scene#28
        talkData.Add(2000, new string[] { "Normal" });
        talkData.Add(100, new string[] { "もういちどだけ…、な？" });
        talkData.Add(200, new string[] { "そうか、わかった。無理しないで。" });
        //quest Talk
        talkData.Add(10 + 2000, new string[]{"また、布地を織ってくれ。" ,
                                             "女房：はたをおるのは、しばらくやすみたいのです。",
                                              });
        talkData.Add(11 + 2000, new string[] { });

        talkData.Add(30 + 2000, new string[] { "なんでそんあにお金がいります。 ", "女房：なんでそんあにお金がいります。"
        ,"金はいくらあっても、こまることはない。","女房：ふたりして暮らせさえすれば、十分ですのに。"
        ,"お金だけあれば、すきなものは買えるし、商売の元手もこしらえる。"+"もっといいくらしができるようになるんだぞ！"
        ,"女房：それでは、いまひとつ、織ってしんぜましょう。"
        +"ほんとに、二どとふたたび織れませんけれど。"
        ,"ありがとう。"
        ,"女房：わかりました。"
        +"ごじょうですから、けして、のぞかず。"});
        talkData.Add(50 + 200, new string[] { "そうか、わかった。無理しないで。" });

        //Scene#29
        talkData.Add(70 + 3000, new string[] { "今日で五日め。奥の間のしごとは、まえよりもっとひまがかかりそうだ。"
            ,"そういえば、よめさ、さいきん、すこしやせたか？はたを織るたびに、ひどくやつれてる。"
            ,"奥ではいったい、なにがおこなわれているのやら。"+"どうしてあんなに美しいものが仕上がるのやら。"
            ,"そうだ！めおとなんだ！すこしようすを見るくらいかまわないだろう。"});
       
        
        //Scene#30
        talkData.Add(90 + 3000, new string[] { "あれから時間がどれくらい経ったのか。"+"あなたのもとに帰りたい…"
,"でもこの見苦しい姿をあなたのお目にかけしまったからには、恥ずかしくて顔を見に行くこともできない。"
,"'この一羽の鶴のように一緒にいられたらいいのに。'"});

        talkData.Add(100 + 4000, new string[] { "あ, あそこにその人がいる. 近寄れないかな。" });
        
        //Scene#32
        //talkData.Add(110 + 3000, new string[] { "このままばれずに飛んでいってしまわなければならない。"
        //,"あっ, わなが."});
        //Scene#33
       // talkData.Add(130 + 3000, new string[] { "よし、もう、大丈夫だ。" + "これからは、気をつけるんだよ。" });
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