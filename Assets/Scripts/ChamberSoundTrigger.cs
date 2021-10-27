using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberSoundTrigger : MonoBehaviour
{
    public GameObject chamberSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chamberSound.GetComponent<AudioSource>().Play();
    }
}
