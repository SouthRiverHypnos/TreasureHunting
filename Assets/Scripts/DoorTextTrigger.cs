using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTextTrigger : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Player;
    public GameObject Door;

    private void Start()
    {
        Text1.SetActive(false);
        Text2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Player.GetComponent<Flying>().withBook)
        {
            Text1.SetActive(true);
        }
        if (Player.GetComponent<Flying>().withBook) {
            Text2.SetActive(true);
            if (Input.GetKeyUp(KeyCode.Q)) {
                Door.GetComponent<SpriteRenderer>().enabled = false;
                Door.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (!Player.GetComponent<Flying>().withBook)
        {
            Text1.SetActive(false);
        }
        if (Player.GetComponent<Flying>().withBook)
        {
            Text2.SetActive(false);
        }
    }
}
