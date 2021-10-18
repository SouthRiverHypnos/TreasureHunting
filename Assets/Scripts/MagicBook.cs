using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBook : MonoBehaviour
{
    public GameObject Text;
    public GameObject Player;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Player.GetComponent<Flying>().withBook = true;
        Text.SetActive(false);
    }
}
