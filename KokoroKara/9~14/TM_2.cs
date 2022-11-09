using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM_2 : MonoBehaviour
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
        //Scene#9
        talkData.Add(3000, new string[] { "…?" });
        talkData.Add(100, new string[] { "しばらく家で休んでおいでなさい。" });
        talkData.Add(200, new string[] { "ここからわかれだね" });
        talkData.Add(10 + 3000, new string[] { "…。" });
        talkData.Add(11 + 3000, new string[] { });

        talkData.Add(30 + 3000, new string[] { "お雪：ありがとうございます。", "お雪：ありがとうございます。" });

        talkData.Add(50 + 3000, new string[] { "あなたのおそばにいたいです。", "あなたのおそばにいたいです。" });
       
        //Scene#11
        talkData.Add(300, new string[] { "あれはおれがまだ十八歳のころだった。" });
        talkData.Add(400, new string[] { "いや、やっぱり夢で見たと思う。" });
        //quest Talk
        talkData.Add(70 + 3000, new string[]{"なあ、お雪。",
                                             "お雪：なあに、あなた",
                                              "おまえが、よめにきてくれて、ほんとうにうれしいよ。そういえば、おまえとはじめてあったのも、" +
                                              "こんな雪の日だったなぁ。",
                                              "おまえはここにはじめて来た時とひとつも変わらない。いまでも、あのときのように若くて美しい…。",
                                              "お雪：いやですは、そんなこと。",
                                              "おまえが、そうやって顔に明かりを受けながら、しごとをしているところを見ると、おれは、十八の年に会ったふしぎな出来事を思い出すよ。" ,
                                              "おれはそのとき、ちょうど今のおまえのような、器量のいい、色の白い女を見たのだ。",
                                              "その女は、じっさい、おまえにそっくりだったぜ。",
                                              "お雪：その方のおはなしをしてくださいな。あなた、どこで、その方をごらんのなりましたの。"});
        talkData.Add(71 + 3000, new string[] { });

        talkData.Add(90 + 3000, new string[] { " ", "やまで、吹雪いての、おれと爺さんはやまの木こり小屋で、夜をあかすことになった。 " ,
        "そのときじゃ、その女にあったのは…。白い女がにっこりと笑いながら、おれの上に身をかがめてきた。",
        "むろん、その女は人間ではなかった。おれはそのときその女が恐ろしかった。",
        "恐ろしかったが、しかし、色は抜けるほど白い顔で、長い真っ黒な髪をうしろにむすんで、唇だけが赤い。",
        "おれは、あのとき夢を見たのか、それとも雪女を見たのか、いまだにはっきりわからないが、あんなよく似た美しい女を見たのは、あのとき一どきりだ。",
        "いままでだれにもいわなかったけど、おまえのそのかおを見てたら思い出した。"});
        talkData.Add(110 + 400, new string[] { "いや、やっぱり夢で見たと思う。" });
        talkData.Add(110 + 3000, new string[] { "　", "お雪：...。" });

        //Scene#13
        talkData.Add(130 + 3000, new string[]{"お雪：それはわたしじゃ。……このわたしじゃ。おゆきじゃ。あなた、とうとうはなしてしまったのね",
                                             "えっ、なんだい、お雪",
                                              "お雪：あれほど言ってはいけないといっておいたのに。" +
                                              "あれほど約束していたのに。あのとき、なにかやくそくしなかったかい？",
                                              "お雪：わたしは、あなたに、言っておいたはずだよ。"+
                                              "あのとき、ひとことでもしゃべれば命をとると、たしかに言っておいた。",
                                              "おまえ、どうしたんだ、お雪…お前は",
                                              "お雪：どうして…どうしてあなたは喋ってしまったの。"+
                                              "わたしは本当にあなたといつまでもくらしたかったのよ。",
                                              "雪女：あなたが言った通り私は雪女です。" +
                                              "いまはもう、こどもたちがいるから命はとらないけど、これで私たちはお別れです。",
                                              "雪女：こんな醜い姿が見せたままでは、恥ずかしくてあなたのそばにいるのはできません。"+
                                              "わたしがでていきます。子どもたちをたのみます。",
        "お雪、いかないでくれ"});

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