using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{

    public GameObject Text;
    public GameObject Player;


    void Start()
    {
        Text.GetComponent<SpriteRenderer>().enabled = false;
        Text.GetComponent<Animator>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger : " + other);
        Text.GetComponent<SpriteRenderer>().enabled = true;
        Text.GetComponent<Animator>().enabled = true;
        Player.GetComponent<AudioSource>().Play();

    }

    void OnTriggerExit2D(Collider2D Other)
    {
        Text.GetComponent<SpriteRenderer>().enabled = false;
        Text.GetComponent<Animator>().enabled = false;
    }

}
