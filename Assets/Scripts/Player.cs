using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Nicolas
    public int strength, defense, luck, gold, health;
    public int equipStrength, equipDefense, equipLuck;
    public float difficulty = 1.4f;
    //<Nicolas>

    public Rigidbody2D rb;
    public Boolean PlayerTurn = true;
    public List<Item> inventory;
    public Item[] equipped;
    Item interim = new Item();
    static Item emptyItem = new Item();
    public event EventHandler PlayerMoved;
    System.Random random = new System.Random();
    public Boolean didPlayerMove = false;
    public Boolean playerInInventory = false;


    public virtual void OnPlayerMoved(EventArgs e)
    {
        EventHandler handler = PlayerMoved;
        if (handler != null)
        {
            handler(this, e);
        }
        didPlayerMove = false;
    }

    public void SavePlayer()
    {
        GlobalInfo.Instance.strength = strength;
        GlobalInfo.Instance.defense = defense;
        GlobalInfo.Instance.luck = luck;
        GlobalInfo.Instance.gold = gold;
        GlobalInfo.Instance.inventory = inventory;
        GlobalInfo.Instance.equipped = equipped;
        GlobalInfo.Instance.health = health;
    }

    void Start()
    {
        strength = GlobalInfo.Instance.strength;
        defense = GlobalInfo.Instance.defense;
        luck = GlobalInfo.Instance.luck;
        gold = GlobalInfo.Instance.gold;
        inventory = GlobalInfo.Instance.inventory;
        equipped = GlobalInfo.Instance.equipped;
        health = GlobalInfo.Instance.health;
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        equipStrength = 0;
        equipDefense = 0;
        equipLuck = 0;

        
        
        if (didPlayerMove)
        {
            OnPlayerMoved(EventArgs.Empty);
        }
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");




        if (health > 0)
        {
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                if (PlayerTurn == true)
                {
                    //Creates Vector for a new targeted position
                    Vector2 targetMovePosition = new Vector2(transform.position.x, transform.position.y + 1);
                    //Creates a raycast at the target position which only travels for up 0.1f before ending
                    RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up, 0.1f);

                    //If ray does not hit/collide sets new position to the target
                    if (hit.collider == null || hit.collider.gameObject.name == "Stairs" || hit.collider.gameObject.name == "Gold(Clone)" || hit.collider.gameObject.name == "ItemTile(Clone)")
                    {
                        transform.position = targetMovePosition;
                        SavePlayer();
                    }


                    else { Debug.Log("Ray Hit: " + hit.transform.name); }
                    if (hit.collider != null && hit.collider.gameObject.name == "Enemy(Clone)")
                    {
                        Destroy(hit.collider.gameObject);
                    }

                    print("up key was pressed");
                    didPlayerMove = true;

                }
            }

            if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            {
                if (PlayerTurn == true)
                {
                    //Creates Vector for a new targeted position
                    Vector2 targetMovePosition = new Vector2(transform.position.x, transform.position.y + -1);
                    //Creates a raycast at the target position which only travels for up 0.1f before ending
                    RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up, 0.1f);

                    //If ray does not hit/collide sets new position to the target
                    if (hit.collider == null || hit.collider.gameObject.name == "Stairs" || hit.collider.gameObject.name == "Gold(Clone)" || hit.collider.gameObject.name == "ItemTile(Clone)")
                    {
                        transform.position = targetMovePosition;
                        SavePlayer();
                    }


                    else { Debug.Log("Ray Hit: " + hit.transform.name); }
                    if (hit.collider != null && hit.collider.gameObject.name == "Enemy(Clone)")
                    {
                        Destroy(hit.collider.gameObject);
                    }

                    print("down key was pressed");
                    didPlayerMove = true;
                }
            }

            if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
            {
                if (PlayerTurn == true)
                {
                    //Creates Vector for a new targeted position
                    Vector2 targetMovePosition = new Vector2(transform.position.x - 1, transform.position.y);
                    //Creates a raycast at the target position which only travels up for 0.1f before ending
                    RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up, 0.1f);

                    //If ray does not hit/collide sets new position to the target
                    if (hit.collider == null || hit.collider.gameObject.name == "Stairs" || hit.collider.gameObject.name == "Gold(Clone)" || hit.collider.gameObject.name == "ItemTile(Clone)")
                    {
                        transform.position = targetMovePosition;
                        SavePlayer();
                    }

                    else { Debug.Log("Ray Hit: " + hit.transform.name); }
                    if (hit.collider != null && hit.collider.gameObject.name == "Enemy(Clone)")
                    {
                        Destroy(hit.collider.gameObject);
                    }

                    print("left key was pressed");
                    didPlayerMove = true;
                }
            }

            if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                if (PlayerTurn == true)
                {
                    //Creates Vector for a new targeted position
                    Vector2 targetMovePosition = new Vector2(transform.position.x + 1, transform.position.y);
                    //Creates a raycast at the target position which only travels up for 0.1f before ending
                    RaycastHit2D hit = Physics2D.Raycast(targetMovePosition, Vector2.up, 0.1f);

                    //If ray does not hit/collide sets new position to the target
                    if (hit.collider == null || hit.collider.gameObject.name == "Stairs" || hit.collider.gameObject.name == "Gold(Clone)" || hit.collider.gameObject.name == "ItemTile(Clone)")
                    {

                        transform.position = targetMovePosition;
                        SavePlayer();
                    }

                    else { Debug.Log("Ray Hit: " + hit.transform.name); }
                    if (hit.collider != null && hit.collider.gameObject.name == "Enemy(Clone)")
                    {
                        Destroy(hit.collider.gameObject);
                    }

                    print("right key was pressed");

                    didPlayerMove = true;
                }
            }

            if (Input.GetKeyDown("e"))
            {
                PlayerTurn = true;
                print("The E key was pressed. PlayerTurn = " + PlayerTurn);
            }

            //<Allen>


            //Nicolas
            if (Input.GetKeyDown("g"))
            {
                print("The G key was pressed.  Testing Gold gain");
                addGold(10);
            }
            if (Input.GetKeyDown("t"))
            {
                getStrength();
                getLuck();
                getDefense();
            }
        }
        else
        {
            if (Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
            {
                GlobalInfo.Instance.GameOver();
                SceneManager.LoadScene("Room1", LoadSceneMode.Single);
            }
        }


        if (Input.GetKeyDown("1") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(0);
        }
        if (Input.GetKeyDown("2") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(1);
        }
        if (Input.GetKeyDown("3") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(2);
        }
        if (Input.GetKeyDown("4") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(3);
        }
        if (Input.GetKeyDown("5") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(4);
        }
        if (Input.GetKeyDown("6") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(5);
        }
        if (Input.GetKeyDown("7") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(6);
        }
        if (Input.GetKeyDown("8") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(7);
        }
        if (Input.GetKeyDown("9") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(8);
        }
        if (Input.GetKeyDown("0") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(9);
        }
        if (Input.GetKeyDown("-") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(10);
        }
        if (Input.GetKeyDown("=") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            removeItem(11);
        }




        if (Input.GetKeyDown("1") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(0);
        }
        if (Input.GetKeyDown("2") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(1);
        }
        if (Input.GetKeyDown("3") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(2);
        }
        if (Input.GetKeyDown("4") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(3);
        }
        if (Input.GetKeyDown("5") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(4);
        }
        if (Input.GetKeyDown("6") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(5);
        }
        if (Input.GetKeyDown("7") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(6);
        }
        if (Input.GetKeyDown("8") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(7);
        }
        if (Input.GetKeyDown("9") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(8);
        }
        if (Input.GetKeyDown("0") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(9);
        }
        if (Input.GetKeyDown("-") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(10);
        }
        if (Input.GetKeyDown("=") && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            equipItem(11);
        }

        
        //<Nicolas>
    }

    public void addItem(Item item)
    {
        if (inventory.Count < 12)
        {
            inventory.Add(item);
        }
        else
        {
        }
    }


    public void removeItem(int itemIndex)
    {
        try
        {
            inventory.RemoveAt(itemIndex);
        }
        catch
        {

        }
    }

    void equipItem(int invSlot)
    {
        int itemType = (int)inventory[invSlot].itemType - 1;
        List<Item> TempInventory = new List<Item>();

        if (itemType > Item.types)
        {
            return;
        }
        else
        {
            if (equipped[itemType].Equals(emptyItem))
            {
                equipped[itemType] = inventory[invSlot];
                removeItem(invSlot);
                /*foreach(Item item in inventory)
                {
                    if (item != null)
                    {
                        TempInventory.Add(item);
                    }
                }
                inventory = TempInventory;
                TempInventory.Clear();*/
            }
            else
            {
                interim = equipped[itemType];
                equipped[itemType] = inventory[invSlot];
                inventory[invSlot] = interim;
                interim = new Item();
                
            }
        }


    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement);
    }

    //Nicolas
    public void addGold(int inputGold) {
        gold += (int)(inputGold * (1 + this.getLuck() / 5));
    }

    public int getStrength()
    {
        foreach (Item item in equipped)
        {
            equipStrength += item.strength;
        }
        print(strength + equipStrength);
        return strength + equipStrength;

    }
    public int getDefense()
    {
        foreach (Item item in equipped)
        {
            equipDefense += item.defense;
        }
        print(defense + equipDefense);
        return defense + equipDefense;
    }
    public int getLuck()
    {
        foreach (Item item in equipped)
        {
            equipLuck += item.luck;
        }
        print(luck + equipLuck);
        return luck + equipLuck;
    }

    //<Nicolas>
}
