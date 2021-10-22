using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberTrigger : MonoBehaviour
{
    public GameObject Text;
    public GameObject Ghost;
    public GameObject Player;
    void Start()
    {
        Text.GetComponent<SpriteRenderer>().enabled = false;
        Text.GetComponent<Animator>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Text.GetComponent<SpriteRenderer>().enabled = true;
        Text.GetComponent<Animator>().enabled = true;
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        Text.GetComponent<SpriteRenderer>().enabled = false;
        Text.GetComponent<Animator>().enabled = false;
        Ghost.GetComponent<SpriteRenderer>().enabled = true;
        Ghost.GetComponent<BoxCollider2D>().enabled = true;
        Player.GetComponent<Flying>().toChamber = true;
    }
}
