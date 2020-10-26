using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    //This is a mess and I am completely sorry for it.

    public int playerDamage;
    public int Health = 3; //3 hits?
    public int Gold = 5; //Placeholder for testing.
    //GameObject player;
    private Transform target;
    private bool skipMove;
    Player myPlayer;

    public Rigidbody2D en;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        //Pretty much copied this from the tutorial, but I found a way to add pathfinding to the enemy movement. I need to make another class for this, so wanted to run it
        //by you guys first. This is just the normal stuff, just to make sure it works.
    public void enemyMove()
    {
        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        { xDir = target.position.x > transform.position.x ? 1 : -1; }

        AttemptMove<Player>(xDir, yDir);

    }

    protected void onCantMove<T>(T component)
    {
        
        //Player hitPlayer = component as Player;

        //There's no method I saw for losing gold or health for the PLayer, so I just added this in for when that's implemented. (Unless I overlooked it when is possible)
        myPlayer.loseGold(playerDamage);
    }

    //Again, stolen from the tutorial until I can figure the pathfinding
    protected void attemptMove<T>(int xDir, int yDir)
    {

        if (skipMove)
        {

            skipMove = false;
            return;
        }

        base.attemptMove<T>(xDir, yDir);

        skipMove = true;

    }

    public void onDeath() {
        if (Health <= 0)
            myPlayer.addGold(Gold);
    }


}
