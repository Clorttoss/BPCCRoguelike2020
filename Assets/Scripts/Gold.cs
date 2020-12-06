using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Allen
public class Gold : MonoBehaviour
{
 
    private Player PlayerObject;

    // Start is called before the first frame update
    void Start()
    {
    int GoldRoll = Random.Range(10, 30);
    GameObject myGameObject = GameObject.Find("Player");
    PlayerObject = myGameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for a match with the gameobject's name
        if (collision.gameObject.name == "Player")
        {
        int GoldRoll = Random.Range(10, 30);
        PlayerObject.addGold(GoldRoll);
        print("Picked up " + GoldRoll + "gold pieces.");
        Destroy(gameObject);
        }
    }
}
//<Allen>