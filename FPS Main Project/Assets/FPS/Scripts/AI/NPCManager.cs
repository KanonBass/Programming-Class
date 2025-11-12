using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

/* Freya's Additions */
public class NPCManager : MonoBehaviour
{
    private Dictionary<NPCController, int> NPCs = new();

    public void AddNPC(NPCController NPC)
    {
        NPCs.Add(NPC, 0);
        NPC.InteractionStarted += StartInteraction;
    }

    public void RemoveNPC(NPCController NPC)
    {
        NPCs.Remove(NPC);
        NPC.InteractionStarted -= StartInteraction;
    }

    public void StartInteraction(NPCController NPC)
    {
        StartConversationEvent evt = Events.StartConversationEvent;

        if (DecideConversation(NPC) != null)
        {
            evt.conversation = DecideConversation(NPC);
            NPCs[NPC]++;
        }

        EventManager.Broadcast(evt);
    }

    public Conversation DecideConversation(NPCController NPC)
    {
        if (NPC.GetConversation(NPCs[NPC]) != null)
        {
            return NPC.GetConversation(NPCs[NPC]);
        }
        else
        {
            return null;
        }
    }
}
