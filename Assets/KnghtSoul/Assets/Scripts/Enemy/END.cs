using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class END : MonoBehaviour
{

    public UnityEvent end;

    private void Update()
    {
        if (Boss.Hp <= 0)
        {
            end.Invoke();
            StartCoroutine(Credit());
        }
    }
    IEnumerator Credit()
    {
        yield return new WaitForSeconds(2F);

        SceneManager.LoadScene("credit");
    }
}
