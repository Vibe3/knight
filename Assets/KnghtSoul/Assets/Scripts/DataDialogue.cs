using UnityEngine;

[CreateAssetMenu(menuName ="Dialogue/Data")]

public class DataDialogue : ScriptableObject
{
    [Header("對話內容"), TextArea(3, 5)]
    public string[] Dialogues;
}
