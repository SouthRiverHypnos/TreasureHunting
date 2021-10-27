using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTextTrigger : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Player;
    public GameObject Door;
    public bool canOpen = false;

    private void Start()
    {
        Text1.GetComponent<SpriteRenderer>().enabled = false;
        Text2.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!Player.GetComponent<Flying>().withBook)
            {
                Text1.GetComponent<SpriteRenderer>().enabled = true ;
            }
            if (Player.GetComponent<Flying>().withBook)
            {
                Player.GetComponent<AudioSource>().Play();
                Text2.GetComponent<SpriteRenderer>().enabled = true;
                canOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (!Player.GetComponent<Flying>().withBook)
        {
            Text1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Player.GetComponent<Flying>().withBook)
        {
            Text2.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canOpen) {

            if (Input.GetKeyUp(KeyCode.Q))
            {
                Door.GetComponent<SpriteRenderer>().enabled = false;
                Door.GetComponent<BoxCollider2D>().enabled = false;
            }

        }
    }
}
