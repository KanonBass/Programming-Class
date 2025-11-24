using UnityEngine;
using UnityEngine.Events;


/* Freya's Additions */
public class LogButton : MonoBehaviour
{
    public UnityAction<LogEntry> LogButtonPressed;
    public LogEntry logEntry;

    public void InvokeAction()
    {
        LogButtonPressed.Invoke(logEntry);
    }
}
