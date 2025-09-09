using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private string helloText;

    [SerializeField] private TMP_Text textBox;


    InputAction space;

    private void Awake()
    {
        //Print();

        //int max = 100;

        //for(int i = 0; i < max + 1; i++)
        //{
        //    Debug.Log(i);
        //}

        //space = InputSystem.actions.FindAction("Space");
        //space.started += Pressed;

        textBox.text = "Hello Year 2!";
    }

    private void Print()
    {
        //Debug.Log($"Hello {name}");
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //    Debug.Log("You have pressed space");
        //}
        
    }

    //private void Pressed(InputAction.CallbackContext obj)
    //{
    //    Debug.Log("Space Pressed");
    //}
}
