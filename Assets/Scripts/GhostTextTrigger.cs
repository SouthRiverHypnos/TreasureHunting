using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTextTrigger : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Player;
    void Start()
    {
        Text1.SetActive(false);
        Text2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Player.GetComponent<Flying>().toChamber)
        {
            Text1.SetActive(true);
        }

        if (Player.GetComponent<Flying>().toChamber)
        {
            Text2.SetActive(true);
            Player.GetComponent<Flying>().respond = true;
            Player.GetComponent<Flying>().beginRespond = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Player.GetComponent<Flying>().toChamber)
        {
            Text1.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
