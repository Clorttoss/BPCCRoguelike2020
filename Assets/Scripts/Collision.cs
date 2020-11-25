using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Rigidbody2D rb;

    protected void hitCheck(Vector2 targetMovePosition)
    {
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
    }
}
