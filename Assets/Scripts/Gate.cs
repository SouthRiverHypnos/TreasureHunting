using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    public Animator animator;

    public GameObject Score;
    public TMP_Text Clue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            if (Score.GetComponent<ScoreManager>().pt == 12)
            {
                animator.SetBool("Open", true);
            }
            else {
                animator.SetBool("Open", false);
            }
        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            if (animator.GetBool("Open"))
            {
                Clue.enabled = true;
            }
            else {
                Clue.enabled = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Clue.enabled = false;

        }
    }
}
