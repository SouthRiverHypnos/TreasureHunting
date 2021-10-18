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
        Text.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Text.SetActive(true);
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        Text.SetActive(false);
        Ghost.GetComponent<SpriteRenderer>().enabled = true;
        Ghost.GetComponent<BoxCollider2D>().enabled = true;
        Player.GetComponent<Flying>().toChamber = true;
    }
}
