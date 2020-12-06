using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    //This is a mess and I am completely sorry for it.

    public int Gold = 5; //Placeholder for testing.
    public int attack;
    public int defense;
    private Transform target;
    
    Player myPlayer;
    private Animator animator;
    private bool skipMove;
    private System.Random random;
    

    public Rigidbody2D en;

    //JUST UNTIL I FIGURE OUT WHAT I DID WRONG HERE

    //Path nextMove = bestPath[0];
    //bestPath.RemoveAt(0);


    // Start is called before the first frame update
    void Start()
    {
        attack = GlobalInfo.Instance.level;
        defense = GlobalInfo.Instance.level - 1;
        Gold = 5 * GlobalInfo.Instance.level;
        this.animator = GetComponent<Animator>();
        this.random = new System.Random();
        //GameManager.instance.AddMyEnemyToList (this);
        GameObject playerGameObject = GameObject.Find("Player");
        myPlayer = playerGameObject.GetComponent<Player>();
        this.myPlayer.PlayerMoved += this.myPlayer_PlayerMoved;
        if (random.Next(0, 3) == 1)
        {
            this.skipMove = false;
        }
        else
        {
            this.skipMove = true;
        }
    }

    void myPlayer_PlayerMoved(object Sender, EventArgs e)
    {
        if (this != null)
        {
            if (!skipMove)
            {
                enemyMove();
            }
            skipMove = !skipMove;
        }
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

        if (myPlayer.transform.position.x > this.transform.position.x)
        {
            xDir = 1;
        }
        else if (myPlayer.transform.position.x == this.transform.position.x)
        
        {
            if (myPlayer.transform.position.y > this.transform.position.y)
            {
                yDir = 1;
            } else if (myPlayer.transform.position.y < this.transform.position.y)
            {
                yDir = -1;
            }
        }
        else if (myPlayer.transform.position.x < this.transform.position.x)
        {
            xDir = -1;
        }


        Vector2 movePosition = new Vector2(this.transform.position.x + xDir, this.transform.position.y + yDir);
        RaycastHit2D hit = Physics2D.Raycast(movePosition, Vector2.up, 0.1f);

        if (hit.collider == null || hit.collider.gameObject.name == "Stairs" || hit.collider.gameObject.name == "Gold(Clone)" || hit.collider.gameObject.name == "ItemTile(Clone)")
        {
            this.transform.position = movePosition;
        }
        if (hit.collider != null && hit.collider.gameObject.name == "Player")
        {
            if (random.Next(1, myPlayer.getDefense() + 1) <= attack)
            {
                myPlayer.health--;
                print("Player says ow!");
            }
            print("Enemy Attacked.");
        }


        
        print("Enemy moved.");
    }

    //This is the basic attack method of just walking up to the player and whacking them.
    



    public void onDeath()
    {
        myPlayer.addGold(Gold);
        Destroy(gameObject);
    }
}


  /*  private List<Path> GetAdjacentSquares(Path p)
    {
        List<Path> ret = new List<Path>();
        int _x = p.x;
        int _y = p.y;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                int __x = _x + x; // easier than writing (_x + x) 5 times
                int __y = _y + y; // easier than writing (_y + y) 5 times
                                  // skip self and diagonal squares
                if ((x == 0 && y == 0) || (x != 0 && y != 0))
                    continue;
                else if (__x < GameManager.instance.numCols &&
                    __y < GameManager.instance.numRows &&
                    __x >= 0 &&
                    __y >= 0 &&
                    !CheckForCollision(new Vector2(_x, _y), new Vector2(__x, __y)))
                    ret.Add(new Path(p.g + 1, BlocksToTarget(new Vector2(__x, __y), target.position), p, __x, __y));
            }
        }
        return ret;
    }

    private bool CheckForCollision(Vector2 start, Vector2 end)
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Linecast(start, end, blockingLayer);
        this.GetComponent<BoxCollider2D>().enabled = true;
        // trying to walk into a wall, change direction
        if (hit.transform != null && !hit.collider.tag.Equals("Player"))
        {

            return true;
        }
        return false;
    }

    function HappyPath()
    {
        Path destinationSquare = new Path(target.position.x, target.position.y);
        evaluationList.Add(new Path(transform.position.x, transform.position.y));
        Path currentSquare = null;
        while (evaluationList.Count > 0)
        {
            currentSquare = itemWithLowestFScore(evaluationList);
            closedPathList.Add(currentSquare);
            evaluationList.Remove(currentSquare);
            // The target has been located
            if (doesPathListContain(closedPathList, destinationSquare))
            {
                return buildPath(currentSquare);
                break;
            }
            List adjacentSquares = GetAdjacentSquares(currentSquare);
            foreach (Path p in adjacentSquares)
            {
                if (doesPathListContain(closedPathList, p))
                    continue; // skip this one, we already know about it
                if (!doesPathListContain(evaluationList, p))
                {
                    openPathList.Add(p);
                }
                else if (p.H + currentSquare.G + 1 < p.F)
                    p.parent = currentSquare;
            }

        }
    }

    private List buildPath(Path p)
    {
        List bestPath = new List();
        Path currentLoc = p;
        bestPath.Insert(0, currentLoc);
        while (currentLoc.parent != null)
        {
            currentLoc = currentLoc.parent;
            if (currentLoc.parent != null)
                bestPath.Insert(0, currentLoc);
            else
                lastMove = currentLoc;
        }
        return bestPath;
    }

}

class Path : object
{

    public int g;         // Steps from A to this
    public int h;         // Steps from this to B
    public Path parent;   // Parent node in the path
    public int x;         // x coordinate
    public int y;         // y coordinate

    public Path(int _g, int _h, Path _parent, int _x, int _y)
    {
        g = _g;
        h = _h;
        parent = _parent;
        x = _x;
        y = _y;
    }

    public int f // Total score for this
    {
        get
        {
            return g + h;
        }
    }
}
*/
