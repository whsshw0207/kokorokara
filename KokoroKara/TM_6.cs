using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_6 : MonoBehaviour
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

        //Scene#34
        talkData.Add(2000, new string[] { "Normal" });
        talkData.Add(100, new string[] { "おれはもう、おまえが怖いだけだ。" });
        talkData.Add(200, new string[] { "今にも昔にもいい嫁になるため努力したなぁ。" });
        talkData.Add(300, new string[] { "全部、隠そうとしたお前が悪いのだ" });
        //quest Talk
        talkData.Add(10 + 2000, new string[]{"全部思い出した、おれたちは遠い昔にも夫婦だったなぁ","お雪：また、あなたはわたしとのやくそくを破った。"});
        talkData.Add(11 + 2000, new string[] { });


        //EndingA
        talkData.Add(30 + 2000, new string[] { "おれはもう、おまえが怖いだけだ。"+"お前とはもう関わりたくない。"
,"雪女：お話を是非もう少しお聞きください。 正体を隠してあなたががっかりするのも分かりますが、私の醜い姿をあなたに見せることはできませんでした。 "
,"...."
,"雪女：あなたのおやさしい心がしたわしく、それだけをたよりに、おそばにうかがったのでした。夫婦だった頃の思い出さえ捨てないでください。"
,"俺も…盗み見ないと言った約束を破って悪かった。"
,"雪女：私もあなたの前で堂々といられず、ずっと胸が痛かったです。" ,"雪女：あなたのよろこぶ顔をずっと見ていたかったのですが、しょうたいをしられたからには、ここにいることはできません。"
,"雪女：あなた。あなたのことはいつまでもわすれないわ。"
+"雪女：あなたとくらした幸せの日々も決して忘れないわ。"
+"雪女：あなたも元気でいてくださいね"
,"雪女：どうぞ末永く、お幸せに"
+"いつまでも、いつまでも。"
,"エンディングA"
 });

        //EndingB
        talkData.Add(40+ 2000, new string[] { "今にも昔にもいい嫁になるため努力したなぁ。"
            +"おらと夫婦になってくれてありがとう。", "雪女：あなたのおやさしい心がしたわしく、それだけをたよりに、おそばにうかがったのでした。"

,"雪女：あなたのよろこぶ顔をずっと見ていたかったのですが、しょうたいをしられたからには、ここにいることはできません。"
,"雪女：あなた。あなたのことはいつまでもわすれないわ。あなたとくらした幸せの日々も決して忘れないわ。"
,"雪女：あなたも元気でいてくださいね。どうぞ末永く、お幸せに。"
+"いつまでも、いつまでも。さようなら","エンディングB" });

        //EndingC
        talkData.Add(50 + 2000, new string[] { "全部、隠そうとしたお前が悪いのだ。人間でもないものが, もう村におりるな。",
            "雪女：約束を破ったとあなたのせいにしたくないです。 あなたは前世でもこの世でも優しくて立派な夫でした。" 
            ,"雪女：あなたも、今は私たちが夫婦だったときの記憶を持っているでしょう。"
,"それは…。"
,"雪女：私が去った後、あなたひとりで子供をだいじに育てた恩はけして忘れません。"
,"雪女：でも私の醜い姿をあなたに見せることはできませんでした。どうかそうしなければならなかった私の立場を分かってください。"
,"俺はあなたがずっと俺に何か大事なことを隠しているようでいつも不安だった。そんな心配やお金よりはあなたと幸せに生きていくことに集中すればよかったのに…。"
,"雪女：お互いの状況が食い違っていましたね。あなたのよろこぶ顔をずっと見ていたかったのですが、しょうたいをしられたからには、ここにいることはできません。"
,"雪女：あなた。あなたのことはいつまでもわすれないわ。"+"あなたとくらした幸せの日々も決して忘れないわ。"
,"雪女：あなたも元気でいてくださいね。どうぞ末永く、お幸せに。"
+"いつまでも、いつまでも。"
,"エンディングC"
 });





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