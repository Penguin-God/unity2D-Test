using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class talkmanager : MonoBehaviour
{
    Dictionary<int, string[]> talkdata;
    Dictionary<int, Sprite> imgdata;
    public Sprite[] portraitArr;

    private void Awake()
    {
        talkdata = new Dictionary<int, string[]>();
        imgdata = new Dictionary<int, Sprite>();
        GenerateData2();
    }

    void GenerateData2()
    {
        //대화 내용 추가
        talkdata.Add(1000, new string[] { "넌 뭐하는 새끼야?:0", "미:3", "친 새끼네:3" });

        talkdata.Add(2000, new string[] { "와!! 샌즈 아시는구나:5", "겁.나.어.렵.습.니.다.:6" });

        talkdata.Add(100, new string[] { "내가 깨어난다면 모든 인간들을 도륙낼것이라는 나무상자의 의지가 느껴진다." });
        talkdata.Add(200, new string[] { "아쉽게도 별거없는 책상이다." });

        //퀘스트 대화
        talkdata.Add(10 + 1000, new string[] { "야 거기 등신:0", 
                                                "저 샌즈충한테 가면:1", 
                                                "아주 재밌는 일이 있을거야:2" });

        talkdata.Add(11 + 1000, new string[] { "저 샌즈충한테 가라니까 뭐하고 있는거야 빨리가.:0" });

        talkdata.Add(11 + 2000, new string[] {"새들은 지저귀고 꽃들은 피어나고: 4",
                                              "이런 날에 너같은 꼬맹이들은:5",
                                              "지.옥.에.서.불.타.야.되:6",
                                              "어? 근데 내 가스터블레스터가 어디갔지?:4"});

        talkdata.Add(20 + 1000, new string[] {"가스터 블래스터?:1",
                                              "그거 그새끼 보물같은 느낌이야:1",
                                              "근데 잃어버렸다니 너무좋다:2"});

        talkdata.Add(20 + 2000, new string[] { "만약에 찾아주면 심판은 보류해주지:4" });

        talkdata.Add(20 + 5000, new string[] { "엇! 이건 가스터 블래스터다!!", 
                                               "당신은 왠지 끔찍한 시간을 보낼 것 같은 느낌이 든다"});

        talkdata.Add(21 + 2000, new string[] {"어 그건 가스터 블래스터:4",
                                              "이제 너의 Love를 0으로 측정해주마 넘어가라:6",});


        //대화마다 일러스트 다르게 하기
        imgdata.Add(1000 + 0, portraitArr[0]);
        imgdata.Add(1000 + 1, portraitArr[1]);
        imgdata.Add(1000 + 2, portraitArr[2]);
        imgdata.Add(1000 + 3, portraitArr[3]);
        imgdata.Add(2000 + 4, portraitArr[4]);
        imgdata.Add(2000 + 5, portraitArr[5]);
        imgdata.Add(2000 + 6, portraitArr[6]);
        imgdata.Add(2000 + 7, portraitArr[7]);
    }
    //지정된 대화 내용을 반환하는 함수
    public string GetTalk(int id, int talkIndex)
    {
        if (!talkdata.ContainsKey(id))
        {
            if (!talkdata.ContainsKey(id - id % 10))
            {
                //ContainsKey(key); key가 있는지 없는지 확인 
                return GetTalk(id - id % 100, talkIndex);
                //퀘스트 맨 처음 대사도 없는 사물의 경우 기본대사를 가지고 옴 
            }
            else
            {
                //해당 퀘스트 진행 순서 대사가 없을 때 퀘스트 맨 처음 대사를 가지고 옴
                return GetTalk(id - id % 10, talkIndex);
                //id - id % 10; 는 해당 퀘스트 진행 순서 중 대사가 없을 시 
                //id % 10(QuestActionIndex)만큼 빼서 QuestActionIndex가 ++되기 전의 대사를 침
            }
        }

        if (talkIndex == talkdata[id].Length)
            return null;
        else
            return talkdata[id][talkIndex];
    }

    public Sprite GetPortraitArr(int id, int portraitArrIndex)
    {
        return imgdata[id + portraitArrIndex];
    }
}
