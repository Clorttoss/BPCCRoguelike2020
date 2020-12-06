using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoBehaviour
{

    public static GlobalInfo Instance;
    public static GlobalInfo BlankCanvas;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;

            for (int i = 0; i < equipped.Length; i++)
            {
                equipped[i] = new Item();
            }

        } else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public int strength = 1;
    public int defense = 1;
    public int luck = 0;
    public int gold = 0;
    public int health = 3;
    public int level = 1;

    public List<Item> inventory = new List<Item>();
    public Item[] equipped = new Item[Item.types];


    public void GameOver()
    {
        Instance = BlankCanvas;
    }
    
    
}
