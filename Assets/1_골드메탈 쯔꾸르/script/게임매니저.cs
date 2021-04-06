using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 게임매니저 : MonoBehaviour
{
    public talkmanager talkmanager;
    public GameObject scan;
    public GameObject MeunSet;
    public bool isaction;
    public Animator talkpanel;
    public int talkIndex;
    public Image faceimg;
    public Qusetmanager qusetManager;
    public typeEffect talk;
    public Text questing;
    public GameObject player;
    public Animator 초상화;
    public Sprite 일러스트;

    void Start()
    {
        qusetManager.Questid = 10;
        GameLoad();
        questing.text = qusetManager.CheckQuest();
    }

    void Update()
    {
        //서브메뉴창
        if (Input.GetButtonDown("Cancel"))
        {
            if (MeunSet.activeSelf)
                MeunSet.SetActive(false);
            else
                MeunSet.SetActive(true);
        }
    }


    public void Action(GameObject scanob)
    {
        //대화창 반응
        //isaction = true;
        scan = scanob;
        objectdata obdata = scan.GetComponent<objectdata>();
        Talk(obdata.id, obdata.isnpc);

        talkpanel.SetBool("isShow", isaction);
    }

    void Talk(int id, bool isnpc)
    {
        string talkdata = "";
        int questTalkIndex = 0;
        //set talk data
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = qusetManager.GetQuestTalkIndex(id);
            talkdata = talkmanager.GetTalk(id + questTalkIndex, talkIndex);
        }

        if (talkdata == null)
        {
            //이야기 끝
            isaction = false;
            talkIndex = 0;
            //대화가 끝나면 퀘스트id값이 오름
            questTalkIndex = qusetManager.GetQuestTalkIndex(id);
            qusetManager.CheckQuest(id);
            questing.text = qusetManager.CheckQuest();
            return;
            //void에서의 return은 강제 함수종료
        }
        //대화 계속할시
        if (isnpc)
        {
            //typeEffect의 함수를 가져와서 실행
            talk.SetMsg(talkdata.Split(':')[0]); 

            //일러스트 보여주기
            faceimg.sprite = talkmanager.GetPortraitArr(id, int.Parse(talkdata.Split(':')[1]));
            faceimg.color = new Color(1, 1, 1, 1);
            //일러스트 애니메이션
            if (일러스트 != faceimg)
            {
                초상화.SetTrigger("Doit");
                일러스트 = faceimg.sprite;
            }
        }
        else
        {
            talk.SetMsg(talkdata);

            faceimg.color = new Color(0, 0, 0, 0);
        }
        isaction = true;
        talkIndex++;
    }

    public void GameSave()
    {
        // PlayerPrefs : 기본적인 데이터 저장Class(함수아님) 
        //player.x
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);

        //player.y
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);

        //Quest Id
        PlayerPrefs.SetInt("questId", qusetManager.Questid);

        //Quest Action Index
        PlayerPrefs.SetInt("qustactionindex", qusetManager.QuestActionIndex);

        //save
        PlayerPrefs.Save();

        MeunSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        
        //GameSave();함수에서 저장한 값을 가지고 옴
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int Questid = PlayerPrefs.GetInt("questId");
        int QuestActionIndex = PlayerPrefs.GetInt("qustactionindex");

        //가지고온 값을 현재 플레이어에게 적용
        player.transform.position = new Vector3(x, y, 0);
        qusetManager.Questid = Questid;
        qusetManager.QuestActionIndex = QuestActionIndex;

        //오브젝트는 기본적으로 꺼져있기 때문에 함수를 실행
        qusetManager.ControlObject();
    }


    public void GameExit()
    {
        //게임종료함수(유니티내에서는 확인을 못하고 게임을 빌드후 실제 플레이 하면서 확인해야함)
        Application.Quit();
    }
}
