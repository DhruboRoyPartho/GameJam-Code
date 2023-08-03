using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotLogic : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpStrenght = 5;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate the horizontal movement
        float horizontalMovement = moveInput * moveSpeed * Time.deltaTime;

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalMovement, 0f, 0f);

        // Move the character to the new position
        transform.position = newPosition;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
            myRigidBody.AddForce(new Vector2(0f, jumpStrenght), ForceMode2D.Impulse);
    }
}
