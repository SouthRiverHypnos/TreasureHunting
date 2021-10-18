using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowPlayerDies : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<MainCharacter>().isCovered == false) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
        }
    }
}
