using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialog : MonoBehaviour
{
    public float timer = 0;
        void Update()
        {
        if (GetComponent<SpriteRenderer>().enabled && !GetComponent<Animator>().GetBool("selection"))
        {
            timer += Time.deltaTime;
        }
        if (timer > 3) {
            GetComponent<Animator>().SetBool("selection", true);
            Debug.Log("selection");
        }

    }
     
}
