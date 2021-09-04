using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeDinoController : MonoBehaviour
{
    //public properties
    public float velocityX = 7;
    

    // Start is called before the first frame update

    //private components

    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;

    //private properties

    private bool isDead = false;

    //constants

    private const int ANIMATION_WALK = 0;
    private const int ANIMATION_DIE = 1;

    private const int LAYER_REDHATFEET = 12;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-velocityX, rb.velocity.y);
        sr.flipX = true;
        changeAnimation(ANIMATION_WALK);

        if(isDead)
        {
            velocityX = 0;
            changeAnimation(ANIMATION_DIE);
        }
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        if(collision.gameObject.layer == LAYER_REDHATFEET && !isDead)
        {
            isDead = true;
        }
    }



    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
