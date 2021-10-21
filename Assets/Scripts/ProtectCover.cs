using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectCover : MonoBehaviour
{
    public float interval;

    void CountDown() {
        if (interval > 0)
        {

            interval -= Time.deltaTime;

        }
        else if(interval <= 0){

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().enabled && GetComponent<CircleCollider2D>().enabled) {

            CountDown();
        
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pillar")) {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        }
    }
}
