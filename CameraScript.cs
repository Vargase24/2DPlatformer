using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    
    //public float minX, maxX;


    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    void Update()
    {
        if (player !=null && GameObject.Find("player").GetComponent<PlayerScript22>().isAlive)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            transform.position = temp;
        }
    }
}
