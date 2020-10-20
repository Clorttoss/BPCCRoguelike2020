using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Rigidbody2D rb;
    //Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");



        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            print("up key was pressed");

            transform.position = new Vector2(transform.position.x, transform.position.y+1);
        }
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            print("down key was pressed");
            transform.position = new Vector2(transform.position.x, transform.position.y-1);
        }
        if(Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            print("left key was pressed");
            transform.position = new Vector2(transform.position.x-1, transform.position.y);
        }
        if(Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            print("right key was pressed");
            transform.position = new Vector2(transform.position.x+1, transform.position.y);
        }
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement);
    }
}
