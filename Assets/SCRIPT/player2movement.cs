using UnityEngine;
using UnityEngine.InputSystem;

public class player2movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}
