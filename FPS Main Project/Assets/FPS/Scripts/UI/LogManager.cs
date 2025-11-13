using System.Collections.Generic;
using TMPro;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

/* Freya's Additions */
public class LogManager : MonoBehaviour
{
    [SerializeField] private GameObject logRoot;

    [SerializeField] private GameObject activeSection;
    [SerializeField] private GameObject completedSection;

    [SerializeField] private GameObject infoNameObject;
    [SerializeField] private GameObject infoGiverObject;
    [SerializeField] private GameObject infoDescriptionObject;

    [SerializeField] private string nameDefaultText;
    [SerializeField] private string giverDefaultText;
    [SerializeField] private string descriptionDefaultText;    

    private TMP_Text nameText;
    private TMP_Text giverText;
    private TMP_Text descriptionText;

    [SerializeField] LogEntry defaultEntry = new();

    [SerializeField] private GameObject buttonPrefab;

    private Dictionary<string, GameObject> objectiveObjectPairs = new();

    private void Awake()
    {
        EventManager.AddListener<ObjectiveUpdateEvent>(UpdateEntry);
        Objective.OnObjectiveCreated += AddEntry;
        Objective.OnObjectiveCompleted += CompleteEntry;
    }

    private void Start()
    {
        nameText = infoNameObject.GetComponent<TMP_Text>();
        giverText = infoGiverObject.GetComponent<TMP_Text>();
        descriptionText = infoDescriptionObject.GetComponent<TMP_Text>();

        defaultEntry.questName = nameDefaultText;
        defaultEntry.questGiver = giverDefaultText;
        defaultEntry.description = descriptionDefaultText;
    }

    private void Update()
    {
        if (Input.GetButtonDown(GameConstants.k_ButtonNameLogMenu))
        {
            SetActivation(!logRoot.gameObject.activeSelf);
        }
    }

    public void AddEntry(Objective objective)
    {
        var newButton = Instantiate(buttonPrefab, activeSection.transform);
        newButton.GetComponentInChildren<TMP_Text>().text = objective.logEntry.questName;

        //The buttons would instantiate with random z values for some reason so I am manually setting it to zero here
        newButton.transform.position.Set(newButton.transform.position.x, newButton.transform.position.y,0);

        objectiveObjectPairs.Add(objective.logEntry.ID, newButton);
        newButton.GetComponent<LogButton>().logEntry = objective.logEntry;
        newButton.GetComponent<LogButton>().LogButtonPressed += SetCurrentLog;
    }

    public void SetActivation(bool isNowActive)
    {
        logRoot.SetActive(isNowActive);

        if (logRoot.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            SetCurrentLog(defaultEntry);
        }
    }

    public void SetCurrentLog(LogEntry newEntry)
    {
        nameText.text = newEntry.questName;
        giverText.text = newEntry.questGiver;
        descriptionText.text = newEntry.description;
    }

    public void UpdateEntry(ObjectiveUpdateEvent evt)
    {
        if (objectiveObjectPairs.ContainsKey(evt.Objective.logEntry.ID))
        {
            var buttonObject = objectiveObjectPairs[evt.Objective.logEntry.ID];

            buttonObject.GetComponent<LogButton>().logEntry = evt.Objective.logEntry;
        }
    }

    public void CompleteEntry(Objective objective)
    {
        var buttonObject = objectiveObjectPairs[objective.logEntry.ID];

        buttonObject.GetComponent<LogButton>().logEntry = objective.logEntry;
        buttonObject.transform.SetParent(completedSection.transform);
    }
}
