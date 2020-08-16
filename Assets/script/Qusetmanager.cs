using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qusetmanager : MonoBehaviour
{
    public int Questid;
    public int QuestActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QusetData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QusetData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QusetData("마을의 특출난 등신들과 대화하기", new int[] { 1000, 2000 }));

        questList.Add(20, new QusetData("샌즈의 가스터 블레스터 찾아주기", new int[] { 5000, 2000 }));

        questList.Add(30, new QusetData("퀘스트 끗", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return Questid + QuestActionIndex;
    }

    public string CheckQuest(int id)
    {
        //진행중인 퀘스트관련npc와 대화했을때만  QuestActionIndex값이 오르게함
        if (id == questList[Questid].npcid[QuestActionIndex])
        {
 //QuestActionIndex를 0으로 설정해 QuestActionIndex가 오를때마다 questList의 int 배열순서에따라 npcid를 지정할 수 있음
            QuestActionIndex++;
        }

        //퀘스트 물건 숨기기/드러내기
        ControlObject();

        //퀘스트 대화순서가 그 퀘스트에 마지막 대화순서일때 함수가 작동해서 다음 퀘스트가 진행되게 해줌
        if (QuestActionIndex == questList[Questid].npcid.Length)
        {
            NextQuest();
        }

        //quest name
        return questList[Questid].questName;
    }

    //매개변수 다르게 해서 함수를 이용하면 같은 함수라도 다른 값이 나옴(오버로딩(Overloding))
    public string CheckQuest()
    {
        //퀘스트 이름
        return questList[Questid].questName;
    }

    void NextQuest()
    {
        Questid += 10;
        QuestActionIndex = 0;
    }

    public void ControlObject()
    {
        switch (Questid)
        {
            case 10:
                if (QuestActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (QuestActionIndex == 0)
                    questObject[0].SetActive(true);
                if (QuestActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
            case 30:
                questObject[0].SetActive(false);
                break;
        }
    }
}
