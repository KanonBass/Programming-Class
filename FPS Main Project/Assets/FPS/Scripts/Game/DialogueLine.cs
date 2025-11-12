using UnityEngine;

/* Freya's Additions */
[CreateAssetMenu(fileName = "DialogueLine", menuName = "Scriptable Objects/DialogueLine")]
public class DialogueLine : ScriptableObject
{
    public string ID;
    public string Text;
    public string Speaker;
}
