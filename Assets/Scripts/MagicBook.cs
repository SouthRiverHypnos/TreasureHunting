using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBook : MonoBehaviour
{
    public GameObject Text;
    public GameObject Player;

    private void Start()
    {
        Text.GetComponent<SpriteRenderer>().enabled = false;
        Text.GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Text.GetComponent<SpriteRenderer>().enabled = true;
        Text.GetComponent<Animator>().enabled = true;
        Player.GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Player.GetComponent<Flying>().withBook = true;
        Text.GetComponent<SpriteRenderer>().enabled = false;
        Text.GetComponent<Animator>().enabled = false;
    }
}
