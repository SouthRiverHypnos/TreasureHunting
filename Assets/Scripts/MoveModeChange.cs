using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveModeChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Change Mode");
            collision.gameObject.GetComponent<Flying>().canFly = false;
            collision.gameObject.GetComponent<Flying>().simpleMove = true;
        }
    }
}
