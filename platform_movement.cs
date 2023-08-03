using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_movement : MonoBehaviour
{
    public float moveDistance = 3f;
    public float x = 0f;
    public float moveSpeed = 1f;
    public bool forward = true;
    public bool backward = false;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (forward)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            x = x + 1 * Time.deltaTime;
        }
        if (backward)
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            x = x - 1 * Time.deltaTime;
        }

        if (x > moveDistance) {
            forward = false;
            backward = true;
        }
        if (x < 0)
        {
            forward = true;
            backward = false;
        }
    }
}
