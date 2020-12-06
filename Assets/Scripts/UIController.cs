using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    //Allen
    private Player PlayerObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject myGameObject = GameObject.Find("Player");
        PlayerObject = myGameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        int inventoryY = 50;
        int index = 1;
        if (PlayerObject.health > 0)
        {
            GUI.Label(new Rect(100, 280, 100, 20), "HP/HP: " + PlayerObject.health + "/3");
            GUI.Label(new Rect(100, 300, 100, 20), "Attack: " + PlayerObject.strength);
            GUI.Label(new Rect(100, 320, 100, 20), "Defense: " + PlayerObject.defense);
            GUI.Label(new Rect(100, 340, 100, 20), "Gold: " + PlayerObject.gold);


            GUI.Label(new Rect(31, 160, 300, 20), "Equipped: " + PlayerObject.equipped[0].ToString());
            GUI.Label(new Rect(31, 180, 300, 20), "Equipped: " + PlayerObject.equipped[1].ToString());
            GUI.Label(new Rect(31, 200, 300, 20), "Equipped: " + PlayerObject.equipped[2].ToString());
            GUI.Label(new Rect(31, 220, 300, 20), "Equipped: " + PlayerObject.equipped[3].ToString());
            GUI.Label(new Rect(31, 240, 300, 20), "Equipped: " + PlayerObject.equipped[4].ToString());
            GUI.Label(new Rect(31, 260, 300, 20), "Equipped: " + PlayerObject.equipped[5].ToString());

            GUI.Label(new Rect(1000, inventoryY, 100, 20), "Inventory:");
            inventoryY += 20;
            GUI.Label(new Rect(900, inventoryY, 300, 20), "Press the key to equip the item.");
            inventoryY += 20;
            GUI.Label(new Rect(900, inventoryY, 300, 20), "Press Shift and that key to delete.");
            foreach (Item item in PlayerObject.inventory)
            {
                inventoryY += 20;
                if (index == 10)
                {
                    GUI.Label(new Rect(900, inventoryY, 300, 20), "0:  " + item.ToString());
                }
                else if (index == 11)
                {
                    GUI.Label(new Rect(900, inventoryY, 300, 20), "-:  " + item.ToString());
                }
                else if (index == 12)
                {
                    GUI.Label(new Rect(900, inventoryY, 300, 20), "=:  " + item.ToString());
                }
                else
                {
                    GUI.Label(new Rect(900, inventoryY, 300, 20), index + ":  " + item.ToString());
                }
                index++;
            }



        }
        else
        {
            GUI.Label(new Rect(480, 180, 400, 20), "Game over!  Press Enter to restart!");
        }
    }
    //<Allen>
}
