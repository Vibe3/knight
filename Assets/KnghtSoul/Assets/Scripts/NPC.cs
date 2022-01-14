using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("對話資料")]
    public DataDialogue dataDialogue;
    [Header("對話系統")]
    public DialogueSystem dialogueSystem;
    [Header("觸發對話的對象")]
    public string target = "騎士";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == target)
        {
            dialogueSystem.StartDialogue(dataDialogue.Dialogues);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == target)
        {
            dialogueSystem.StopDialogue();
        }
    }
}
