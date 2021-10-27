using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Transform>().position.y >= 1.3)
        {
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
