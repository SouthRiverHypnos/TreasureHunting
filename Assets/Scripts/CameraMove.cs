using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
    }

    private void Update()
    {
        if (transform.position.y >= 3)
        {
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
        }
    }
}
