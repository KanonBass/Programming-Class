using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private InputAction movement;
    Rigidbody rb;
    Vector2 moveVector;

    [SerializeField] private float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveVector.x * speed, 0, moveVector.y * speed));
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        //Debug.Log($"movement Updated: {moveVector}");
    }
}
