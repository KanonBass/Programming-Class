using Unity.FPS.Game;
using UnityEngine;

/* Freya's Additions */
[CreateAssetMenu(fileName = "Conversation", menuName = "Scriptable Objects/Conversation")]
public class Conversation : ScriptableObject
{
    public string ID;
    public DialogueLine[] Lines;
    public GameObject[] ObjectiveAssignments;
}
