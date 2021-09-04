using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHatFeetController : MonoBehaviour
{
    //private components
    private BoxCollider2D bc;

    //private properties
    //private bool isSliding2 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        //isSliding2 = RedHatController.isSliding;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!isSliding2)
        {
            bc.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            bc.GetComponent<BoxCollider2D>().enabled = true;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FreeDino")
        {
            Debug.Log("Enemigo detectado");
            
        }
    }
}
