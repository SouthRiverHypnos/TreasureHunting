using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldenSnitch : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int spotNumber;
    

    private void Start()
    {
        waitTime = startWaitTime;
        spotNumber = 0;
    }

    private void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spotNumber].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[spotNumber].position) < 0.2f) {
            if (waitTime <= 0)
            {
                if (spotNumber <= 19)
                {
                    spotNumber += 1;
                }
                waitTime = startWaitTime;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}