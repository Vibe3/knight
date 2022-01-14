using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene2 : MonoBehaviour
{
    public string Target = "ÃM¤h";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Target)
        {
            SceneManager.LoadScene("Scenetwo");
        }
    }
}
