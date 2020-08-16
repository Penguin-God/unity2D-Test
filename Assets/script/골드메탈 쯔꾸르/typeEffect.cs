using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typeEffect : MonoBehaviour
{
    string targetMsg;
    public GameObject EndCursor;
    public int CPS;
    AudioSource auido;
    Text msgText;
    int index;
    float count;
    public bool isAnim;


    private void Awake()
    {
        msgText = GetComponent<Text>();
        auido = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

   void EffectStart()
    {
        //Text공백처리
        msgText.text = "";
        index = 0;
        //커서 숨기기
        EndCursor.SetActive(false);

        count = 1.0f / CPS;
        Debug.Log(count);

        isAnim = true;

        Invoke("EffectIng", count);
    }

    void EffectIng()
    {
        //메세지가 다 나오면 커서가 나옴
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        
        //효과음(대사중에 공배과 마침표는 오디오 Play안하게 설정)
        if(targetMsg[index] != ' ' || targetMsg[index] != '.')
            auido.Play();

        index++;

        Invoke("EffectIng", count);
    }

    void EffectEnd()
    {
        isAnim = false;
        //대사끝났으니 커서 보여주기
        EndCursor.SetActive(true);
    }
}
