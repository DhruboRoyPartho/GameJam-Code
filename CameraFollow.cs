using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    //private float minX = -50.0f, maxX = 50.0f;


    private Transform player;
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;  

        //if (tempPos.x > maxX)
        //{
        //    tempPos.x = maxX;
        //}

        //if (tempPos.x < minX)
        //{
        //    tempPos.x = minX;
        //}

        transform.position = tempPos;
    }
}
