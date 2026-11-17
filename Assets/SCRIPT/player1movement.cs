using UnityEngine;
using UnityEngine.InputSystem;

public class player1movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}
