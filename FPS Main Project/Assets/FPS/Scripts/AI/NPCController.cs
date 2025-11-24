using UnityEngine;
using UnityEngine.Events;

/* Freya's Additions */
public class NPCController : Interactable
{
    public UnityAction<NPCController> InteractionStarted;

    [SerializeField] private string ID;
    [SerializeField] private Conversation[] conversations;

    private NPCManager m_NPCManager;

    public override void Start()
    {
        base.Start();

        m_NPCManager = FindFirstObjectByType<NPCManager>();

        m_NPCManager.AddNPC(this);
    }

    protected override void AddInputListener()
    {
        detector.InputDetected += UpdateInput;
    }

    public void UpdateInput()
    {
        if (!MenuStateHandler.menuOpen)
        {
            InteractionStarted.Invoke(this);
        }
    }

    public string GetID()
    {
        return ID;
    }

    private void OnDestroy()
    {
        m_NPCManager.RemoveNPC(this);
    }

    public Conversation GetConversation(int i)
    {
        return conversations[i];
    }
}
