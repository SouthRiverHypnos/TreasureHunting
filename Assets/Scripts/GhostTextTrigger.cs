using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostTextTrigger : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Player;

    public float timer;
    void Start()
    {
        Text1.GetComponent<Animator>().enabled = false;
        Text1.GetComponent<SpriteRenderer>().enabled = false;
        Text2.GetComponent<Animator>().enabled = false;
        Text2.GetComponent<SpriteRenderer>().enabled = false;
        Text3.GetComponent<Animator>().enabled = false;
        Text3.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Player.GetComponent<Flying>().toChamber)
        {
            Text1.GetComponent<SpriteRenderer>().enabled = true;
            Text1.GetComponent<Animator>().enabled = true;
        }

        if (Player.GetComponent<Flying>().toChamber)
        {
            Text2.GetComponent<SpriteRenderer>().enabled = true;
            Text2.GetComponent<Animator>().enabled = true;
            Player.GetComponent<Flying>().simpleMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Player.GetComponent<Flying>().toChamber)
        {
            Text1.GetComponent<Animator>().enabled = false;
            Text1.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void Update()
    {
        if (Text2.GetComponent<Animator>().GetBool("selection"))
        {
            Player.GetComponent<Flying>().end = true;
        }
    }
}

