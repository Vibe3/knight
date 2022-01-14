using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("��ܶ��j"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("��ܮ�")]
    public GameObject godialogue;
    [Header("��ܤ��e")]
    public Text textContent;
    [Header("��ܧ����ϥ�")]
    public GameObject goTip;
    [Header("��ܫ���")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        //StartCoroutine(TypeEffect());
    }

    private IEnumerator TypeEffect(string[] contents)
    {
        string test1 = "123";
        string test2 = "234";

        string[] test = { test1, test2 };


        textContent.text = "";
        godialogue.SetActive(true);


        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";
            goTip.SetActive(false);
            
            for (int i = 0; i < contents[j].Length; i++)
            {
                textContent.text += contents[j][i];
                yield return new WaitForSeconds(interval);
            }

            goTip.SetActive(true);

            while (!Input.GetKeyDown(keyDialogue))
            {
                yield return null;
            }

        }
        godialogue.SetActive(false);
    }


    public void StartDialogue(string[] contents)
    {
        StartCoroutine(TypeEffect(contents));
    }


    public void StopDialogue()
    {
        StopAllCoroutines();
        godialogue.SetActive(false);
    }

   
        
}
