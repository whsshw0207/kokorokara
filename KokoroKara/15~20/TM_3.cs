using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_3 : MonoBehaviour
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
        //Scene#15
        talkData.Add(4000, new string[] { "Normal" });
        talkData.Add(100, new string[] { "ていねいに介抱しなきゃ。" });
        talkData.Add(200, new string[] { "無視したいけど鳴き声うるさいな… 矢だけはひきぬいてくれるのがいいかな." });
        //quest Talk
        talkData.Add(10 + 4000, new string[]{"ふいにばさばさという音がして、来てみたら、こんな…。つばさに矢をうけて、くるしそうに見える。" });
        talkData.Add(11 + 4000, new string[] { });

        talkData.Add(30 + 4000, new string[] {" ", "よし、もう、大丈夫だ。これからは、気をつけるんだよ。" });
        talkData.Add(50 + 200, new string[] {  "無視したいけど鳴き声うるさいな… 矢だけはひきぬいてくれるのがいいかな." });
        talkData.Add(50 + 4000, new string[] { "もう、ここには来るな", "もう、ここには来るな" });
        
        //Scene#17
        talkData.Add(5000, new string[] { "Normal" });
        talkData.Add(300, new string[] { "いきなりそんな…おれは、まずしい。いいくらしは、させられね。" });
        talkData.Add(400, new string[] { "わかった。よめになってくれ。" });
        //quest Talk
        talkData.Add(70 + 5000, new string[]{"はて、こんなよふけにだれじゃろう…。" ,
                                             "女：たびのものです。みちに、まよってしまって…どうかひとばん泊めてください。",
                                              "それは、なんぎな…。さぁ、どうぞ、はいりなされ…。",
                                              "女：そして、わたしをおよめにしてください"});
        talkData.Add(71 + 5000, new string[] { });

        talkData.Add(90 + 5000, new string[] { "　", "女：かまいません。あなたのおそばにいたいのです。" });
        talkData.Add(110 + 400, new string[] { "わかった。よめになってくれ。" });
        talkData.Add(110 + 5000, new string[] { "", "女：私もこんな嬉しいことはございません。よろしくお願いいたします。" });
        
        //Scene#19
        talkData.Add(130 + 5000, new string[] { "よめさまも、きたことだし、こんどの正月は、もうちっとはれやかにしたいけど…。",
                                                "女房：おなごははたお織るもの。わたしにも、ひとつ織らせてください。はたばをつくってくださいませんか？",
                                                "わかった。",
                                                "女房：わたしが、はたをおっているあいだ、けっして中をのぞかないでくださいね…。"});
        //Scene#20
        talkData.Add(140 + 5000, new string[] {"'今日で四日目織りつづけたのか…。やつれたすがただ。'",
            "これはまた、なんという上等の布地か。しっとりとふくよかな美しさだ。",
                                       "女房：これを町へうりにいってくださいな。"});
      


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