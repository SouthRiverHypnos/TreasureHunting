using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flying : MonoBehaviour
{
    public float moveSpeed, flyForce = 1.0f;
    public Rigidbody2D rb;

    public bool hasCover = true;
    public bool isCovered = false;
    public GameObject Cover;

    public bool canFly = false;
    public bool simpleMove = false;

    public float jumpPower = 5.0f;
    public bool isGrounded;
    public bool canJump = false;
    float moveX = 1.0f;

    float timer = 0;
    bool begintimer = true;

    public bool withBook = false;
    public bool toChamber = false;
    public bool end = false;

    public float deathTimer = 0;
    public bool deathReady = false;

    public Animator animator;

    public GameObject beginText;
    public GameObject InstrText;
    public GameObject GhostText;
    public GameObject BGM;
    public GameObject BGMChamber;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isFly", true);

        beginText.GetComponent<SpriteRenderer>().enabled = true;
        beginText.GetComponent<Animator>().enabled = true;
    }

    void Fly() {
        if (Input.GetKeyUp(KeyCode.Space)) {
            rb.velocity = Vector2.up * flyForce;
        }
    }
    void PlayerControls()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            canJump = true;

        }

        moveX = Input.GetAxis("Horizontal");
        animator.SetFloat("MoveX", moveX);
    }

    private void FixedUpdate()
    {
        if (!simpleMove)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

            if (canJump)
            {
                Jump();
                canJump = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            isGrounded = true;
    }

    void Jump()
    {

        if (!isGrounded)
        {
            return;
        }

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;

    }

    void CoverEnable()
    {

        if (!Cover.GetComponent<SpriteRenderer>().enabled && !Cover.GetComponent<CircleCollider2D>().enabled)
        {

            isCovered = false;

        }


        if (hasCover)
        {
            if (Input.GetKeyUp(KeyCode.Keypad0))
            {

                isCovered = true;
                hasCover = false;
                Cover.GetComponent<SpriteRenderer>().enabled = true;
                Cover.GetComponent<CircleCollider2D>().enabled = true;

            }
        }
    }

    void Update()
    {
        CoverEnable();
        if (begintimer)
        {
            timer += Time.deltaTime;
            if (timer > 4)
            {
                canFly = true;
                begintimer = false;
                InstrText.SetActive(true);
                beginText.GetComponent<Animator>().enabled = false;
                beginText.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        

        if (!canFly && !simpleMove) {
            rb.bodyType = RigidbodyType2D.Static;
        }

        if (canFly)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            animator.SetBool("isFly", true);
            Fly();
        }

        if (transform.position.x >= 50.47368) {
            simpleMove = true;
            canFly = false;
            InstrText.SetActive(false);
            BGM.GetComponent<AudioSource>().Stop();
            
        }

        if (simpleMove) {
            PlayerControls();
            animator.SetBool("isFly", false);
        }

        if (end) {
            Debug.Log("End");
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(4);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                GhostText.GetComponent<GhostTextTrigger>().Text2.GetComponent<Animator>().enabled = false;
                GhostText.GetComponent<GhostTextTrigger>().Text2.GetComponent<SpriteRenderer>().enabled = false;
                GhostText.GetComponent<GhostTextTrigger>().Text3.GetComponent<SpriteRenderer>().enabled = true;
                GhostText.GetComponent<GhostTextTrigger>().Text3.GetComponent<Animator>().enabled = true;
                deathReady = true;
            }

            if (deathReady) {
                deathTimer += Time.deltaTime;
            }
        }

        if (deathTimer > 3)
        {
            SceneManager.LoadScene(5);
        }


    }
       
    }
