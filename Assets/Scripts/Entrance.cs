using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            if (animator.GetBool("Open")) {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        
        }
    }


}
