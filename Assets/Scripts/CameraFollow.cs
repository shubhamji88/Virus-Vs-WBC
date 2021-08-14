using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;
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
        if (player.position.x > minX && player.position.x < maxX)
        {
            tempPos.x = player.position.x;
            tempPos.y = player.position.y;
            transform.position = tempPos;
        }
    }
}
