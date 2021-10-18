using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{

    public GameObject Text;


    void Start()
    {
        Text.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger : " + other);
        Text.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        Text.SetActive(false);
    }

}
