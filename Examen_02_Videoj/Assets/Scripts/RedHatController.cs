using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHatController : MonoBehaviour
{
    //public properties
    public float velocityX = 4;
    public float jumpForce = 40;

    // Start is called before the first frame update

    //private components
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;

    //private properties
    private bool isJumping = false;
    private bool isDead = false;

    private int countAvoided = 0;

    //constants
    private const int ANIMATION_RUN = 0;
    private const int ANIMATION_JUMP = 1;
    private const int ANIMATION_SLIDE = 2;
    private const int ANIMATION_DIE = 3;


    private const int LAYER_GROUND = 7;
    private const int LAYER_FREEDINO = 8;
    private const int LAYER_DINOHEAD = 9;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
        changeAnimation(ANIMATION_RUN);

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(ANIMATION_JUMP);
            isJumping = true;
        }
        if(Input.GetKey(KeyCode.X))
        {
            changeAnimation(ANIMATION_SLIDE);
        }
        if(isDead == true)
        {
            velocityX = 0;
            changeAnimation(ANIMATION_DIE);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LAYER_GROUND)
        {
            isJumping = false;
        }
        if(collision.gameObject.layer == LAYER_FREEDINO)
        {
            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == LAYER_DINOHEAD)
        {
            countAvoided = countAvoided + 1;
            Debug.Log("ContadorEvitar: " + countAvoided);
        }
    }

    private void changeAnimation(int animation) 
    {
        animator.SetInteger("Estado", animation);
    }
}
