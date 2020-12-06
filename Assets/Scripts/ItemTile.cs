using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTile : MonoBehaviour
{
    // Start is called before the first frame update
    private Player PlayerObject;
    System.Random rand = new System.Random();
    void Start()
    {
        GameObject myGameObject = GameObject.Find("Player");
        PlayerObject = myGameObject.GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for a match with the gameobject's name
        if (collision.gameObject.name == "Player")
        {
            Item heldItem = new Item(GlobalInfo.Instance.level, rand.Next(1, Item.types + 1));
            PlayerObject.addItem(heldItem);
            print("Picked up an item!");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
