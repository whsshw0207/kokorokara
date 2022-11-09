using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_1 : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //Scene#1
        talkData.Add(1000, new string[] { "Normal" });
        talkData.Add(100, new string[] { "火がきえないようにみていたいから。" });
        talkData.Add(200, new string[] { "大丈夫、さきにやすんでいてくれ。" });
        //quest Talk
        talkData.Add(10 + 1000, new string[]{"茂作：思ったより、早くふぶえてきたなぁ。"+
                                            "今夜はここで泊まるより仕方あるめー。",
                                            "茂作：あすのあさには、ふぶきもおさまるじゃろう。"+
                                            "すこしよこになってたほうがよいぞ。" });
        talkData.Add(11 + 1000, new string[]{   });
        //Scene#3
        talkData.Add(2000, new string[] { "Normal" });
        talkData.Add(300, new string[] { "わ…わかった"});
        talkData.Add(400, new string[] {"…"});
        //quest Talk
        talkData.Add(70 + 2000, new string[]{"なんだ、あそこにいるのは。" +
                                             "だれじゃ、おまえは。こんなところに。",
                                              "雪女：わたしは、おまえも、こっちの人のような目に会わせてやろうと、"+
                                              "思ったけれど、でも、なんだか、とてもかわいそうになってきた。",
                                              "雪女：巳之吉、おまえはかわいい子だね。"+
                                              "みたところおまえはまだ若々しく美しい命がかがやいている。",
                                              "雪女：もう、わるさはしないよ。生き抜くのだ。"+
                                              "そなたはまだ、あまりにも若いから命だけは助けてあげるのだ。",
                                              "雪女：でも、今夜おまえが見たことは、けしてだれにも言ってはいけないよ。"+
                                              "言うと、わたしにゃ、ちゃんとわかるよ。",
                                              "雪女：そのときはおまえのその美しい命がおわってしまうでしょう。"+
                                              "いいかえ、わたしの言ったことを、よくおぼえて置き。"});
        talkData.Add(71 + 2000, new string[] {   });
        
        talkData.Add(90 + 2000, new string[] { "雪女：やくそくしたね。おまえの目は美しい… ", "雪女：やくそくしたね。おまえの目は美しい… " });
        talkData.Add(110 + 400, new string[] { "…" });
        talkData.Add(110 + 2000, new string[] { "雪女：沈黙は肯定だよ。おまえの目は美しい…" , "雪女：沈黙は肯定だよ。おまえの目は美しい…" });
        //Scene#5
        talkData.Add(130 + 3000, new string[] { "こんばんは",
                                                "お雪：こんばんは。わたしはお雪と申します。",
                                                "どこへ行くの？",
        "お雪：近ごろ両親の死にわかれ、これから江戸へ行くのです。",
        "江戸へ？",
        "お雪：江戸には、貧しいけれども親戚が何軒かありますから、そこへ行けば、女中奉公の口ぐらいは、なんとか世話をしてくれるでしょう。"});
        //Scene#7
        talkData.Add(140 + 3000, new string[] { "おまえさん、結婚の約束をした男はないのかえ。",
                                                "お雪：そんあものはありません。",
                                                "お雪：あなたはおかみさんがおありですか、今はなくても、いつかはお嫁さんになるという、きまった人でもおありですか。",
        "いや、自分はまだ年が若いから、今はまだ、嫁のことなぞは考えていない。"});  
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