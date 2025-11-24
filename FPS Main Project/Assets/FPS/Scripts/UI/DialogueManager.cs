using System.Linq;
using TMPro;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;

/* Freya's Additions */
public class DialogueManager : MonoBehaviour
{
    [Tooltip("Root object of textbox")]
    [SerializeField] private GameObject dialogueUI;

    [Tooltip("Textbox object for speaker")]
    [SerializeField] private GameObject speakerTextObject;

    [Tooltip("Textbox object for dialogue")]
    [SerializeField] private GameObject dialogueTextObject;

    private TMP_Text speakerTextBox;
    private TMP_Text dialogueTextBox;

    private bool inDialogue = false;

    private Conversation currentConversation;
    private DialogueLine currentLine;
    private int currentIndex;

    private bool startedThisFrame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.AddListener<StartConversationEvent>(StartConversation);

        speakerTextBox = speakerTextObject.GetComponent<TMP_Text>();
        dialogueTextBox = dialogueTextObject.GetComponent<TMP_Text>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (inDialogue && Input.anyKeyDown && !startedThisFrame)
        {
            ContinueConversation();
        }

        startedThisFrame = false;
    }

    public void StartConversation(StartConversationEvent evt)
    {
        ActivateUI();

        currentConversation = evt.conversation;
        currentIndex = 0;
        currentLine = currentConversation.Lines[currentIndex];
        startedThisFrame = true;

        UpdateTextbox();
    }

    private void ActivateUI()
    {
        dialogueUI.SetActive(true);
        inDialogue = true;
        MenuStateHandler.menuOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    private void UpdateTextbox()
    {
        speakerTextBox.text = currentLine.Speaker;
        dialogueTextBox.text = currentLine.Text;
    }

    private void ContinueConversation()
    {
        currentIndex++;

        if (currentConversation.Lines.Count() > currentIndex)
        {
            currentLine = currentConversation.Lines[currentIndex];
            UpdateTextbox();
        }
        else
        {
            EndConversation();
        }
    }

    private void EndConversation()
    {
        dialogueUI.SetActive(false);
        currentIndex = 0;
        inDialogue = false;
        MenuStateHandler.menuOpen = false;
        AssignObjectives();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public bool GetInDialogue()
    {
        return inDialogue;
    }

    private void AssignObjectives()
    {
        foreach(GameObject objective in currentConversation.ObjectiveAssignments)
        {
            Instantiate(objective);
        }
    }
}
