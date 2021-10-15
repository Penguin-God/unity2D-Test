using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeCoroutine : MonoBehaviour
{
    int test = 12;
    private IEnumerator Start()
    {
        Debug.Log(test);
        yield return new WaitForSeconds(1f);
        TestRef(ref test);
        Debug.Log(test);
        yield return new WaitForSeconds(1f);
        TestOut(out test);
        Debug.Log(test);
    }

    void TestRef(ref int test)
    {
        // ref는 인자 값을 기억함
        Debug.Log("ref ; " + test);
        test += 10;
    }

    void TestOut(out int test)
    {
        test = 24000; // 이렇게 선언하지 않고 사용하면 등록되지 않은 매개변수를 사용한다며 에러 뜸 즉 out은 기존 값을 깡그리 무시하고 새 값을 반환함
        Debug.Log("out ; " + test); 
    }
}