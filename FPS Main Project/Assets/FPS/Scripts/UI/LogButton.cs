using UnityEngine;
using UnityEngine.Events;

public class LogButton : MonoBehaviour
{
    public UnityAction<LogEntry> LogButtonPressed;
    public LogEntry logEntry;

    public void InvokeAction()
    {
        LogButtonPressed.Invoke(logEntry);
    }
}
