using UnityEngine;

/* Freya's Additions */
[RequireComponent (typeof(InteractionArea))]
public abstract class Interactable : MonoBehaviour
{
    protected InteractionArea detector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        FindDetector();
        AddInputListener();
    }

    private void FindDetector()
    {
        detector = GetComponent<InteractionArea>();
    }

    /// <summary>
    /// Add a method as a listener to detector.InputDetected action
    /// </summary>
    protected abstract void AddInputListener();
}
