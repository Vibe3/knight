using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnCoroutine : MonoBehaviour
{
    private IEnumerator Test()
    {
        print("�o�O�Ĥ@�q��r�T��~");
        yield return new WaitForSeconds(1);
        print("�o�O�ĤG�q��r�T��~");
        yield return new WaitForSeconds(3);
        print("�S���F�T����");
    }

    private IEnumerator TestWithloop()
    {
        for (int i = 0; i< 10; i++)
        {
            print("�Ʀr :" + i);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
