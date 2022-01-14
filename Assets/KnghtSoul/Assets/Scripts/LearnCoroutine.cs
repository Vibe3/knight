using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnCoroutine : MonoBehaviour
{
    private IEnumerator Test()
    {
        print("這是第一段文字訊息~");
        yield return new WaitForSeconds(1);
        print("這是第二段文字訊息~");
        yield return new WaitForSeconds(3);
        print("又等了三秒鐘");
    }

    private IEnumerator TestWithloop()
    {
        for (int i = 0; i< 10; i++)
        {
            print("數字 :" + i);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
