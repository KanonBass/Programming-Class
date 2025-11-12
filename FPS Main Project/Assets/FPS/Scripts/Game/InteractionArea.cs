using Unity.FPS.Game;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

/* Freya's Addition */

[RequireComponent(typeof(SphereCollider))]
public class InteractionArea : MonoBehaviour
{
    public UnityAction InputDetected;

    private SphereCollider DetectionTrigger;
    [SerializeField] private float DetectionRadius;

    private bool isInArea = false;

    private void Start()
    {
        DetectionTrigger = GetComponent<SphereCollider>();
        DetectionTrigger.isTrigger = true;
        DetectionTrigger.radius = DetectionRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInArea && Input.GetButtonDown(GameConstants.k_ButtonNameInteraction))
        {
            InputDetected.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInArea = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }
}
