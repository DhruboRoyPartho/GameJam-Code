using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_movement_updown : MonoBehaviour
{
    public float moveTime = 3f;
    public float y = 0f;
    public float moveSpeed = 1f;
    public bool up = false;
    public bool down = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
            y = y - 1 * Time.deltaTime;
        }
        if (down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
            y += (1 * Time.deltaTime);
        }

        if (y > moveTime)
        {
            up = true;
            down = false;
        }
        if (y < 0)
        {
            up = false;
            down = true;
        }
    }
}
