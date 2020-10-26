using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Nicolas
    public int strength = 2, defense = 2, luck = 0, speed = 2, gold = 0, 
        strGold = 100, defGold = 100, luckGold = 200, speedGold = 1000;
    public float difficulty = 1.4f;
    //<Nicolas>

    public Rigidbody2D rb;
    //Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");


        

        //Allen
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            //Creates Vector for a new targeted position
            Vector2 targetMovePosition = new Vector2(transform.position.x, transform.position.y + 1);
            //Shoots a raycast at the target position which only travels for up 0.1f before ending
            RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up,0.1f);

            //If ray does not hit/collide sets new position to the target
            if (hit.collider == null)
            {   
                transform.position = targetMovePosition;
            }else{
                print("Ray cast hit");
                Debug.Log("Ray Hit: " + hit.transform.name);
            }

            print("up key was pressed");
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            //Creates Vector for a new targeted position
            Vector2 targetMovePosition = new Vector2(transform.position.x, transform.position.y + -1);
            //Shoots a raycast at the target position which only travels for up 0.1f before ending
            RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up, 0.1f);

            //If ray does not hit/collide sets new position to the target
            if (hit.collider == null)
            {
                transform.position = targetMovePosition;
            }
            else
            {
                print("Ray cast hit");
                Debug.Log("Ray Hit: " + hit.transform.name);
            }

            print("down key was pressed");
        }

        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            //Creates Vector for a new targeted position
            Vector2 targetMovePosition = new Vector2(transform.position.x-1, transform.position.y);
            //Shoots a raycast at the target position which only travels up for 0.1f before ending
            RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up, 0.1f);

            //If ray does not hit/collide sets new position to the target
            if (hit.collider == null)
            {
                transform.position = targetMovePosition;
            }
            else
            {
                print("Ray cast hit");
                Debug.Log("Ray Hit: " + hit.transform.name);
            }

            print("left key was pressed");
        
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            //Creates Vector for a new targeted position
            Vector2 targetMovePosition = new Vector2(transform.position.x+1, transform.position.y);
            //Shoots a raycast at the target position which only travels up for 0.1f before ending
            RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up, 0.1f);

            //If ray does not hit/collide sets new position to the target
            if (hit.collider == null)
            {
                transform.position = targetMovePosition;
            }
            else
            {
                print("Ray cast hit");
                Debug.Log("Ray Hit: " + hit.transform.name);
            }

            print("right key was pressed");
        //<Allen>

        }
        //Nicolas
        if (Input.GetKeyDown("g"))
        {
            print("The G key was pressed.  Testing Gold gain");
            addGold(10);
        }
        if (Input.GetKeyDown("h"))
        {
            print("The H key was pressed.  Testing strength gain");
            upStrength();
        }
        if (Input.GetKeyDown("j"))
        {
            print("The J key was pressed.  Testing defense gain");
            upDefense();
        }
        if (Input.GetKeyDown("k"))
        {
            print("The K key was pressed.  Testing luck gain");
            upLuck();
        }
        if (Input.GetKeyDown("l"))
        {
            print("The L key was pressed.  Testing Speed gain");
            upSpeed();
        }
        //<Nicolas>

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement);
    }

    //Nicolas
    public void addGold(int inputGold) {
        gold += (int)(inputGold * (1 + luck / 5));
    }

    public void upStrength() {
        if (gold >= strGold) {
            strength += 1;
            gold -= strGold;
            strGold = (int)(strGold * difficulty);
        }
    }
    public void upDefense()
    {
        if (gold >= defGold)
        {
            defense += 1;
            gold -= defGold;
            defGold = (int)(defGold * difficulty);
        }
    }
    public void upLuck()
    {
        if (gold >= luckGold)
        {
            luck += 1;
            gold -= luckGold;
            luckGold = (int)(luckGold * difficulty);
        }
    }
    public void upSpeed()
    {
        if (gold >= speedGold)
        {
            speed += 1;
            gold -= speedGold;
            speedGold = (int)(speedGold * difficulty);
        }
    }
    //<Nicolas>
}
