using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //Allen
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for a match with the gameobject's name
        if (collision.gameObject.name == "Player")
        {
            //Print Message and roll 1-20
            print("Player has reached stairs, Rolling for new dungeon room: " + Random.Range(1, 20));
        }
    }
    //<Allen>

}
