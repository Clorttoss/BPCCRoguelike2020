using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Helmet = 1,
    Chestpiece = 2,
    Leggings = 3,
    Boots = 4,
    Weapon = 5,
    Necklace = 6,
    Scroll = 7,

    //Using the Unspecified as a way to test if an Item is 'empty'.
    Unspecified = 100
}

public class Item
{
    public static int types = 6;
    
    public ItemType itemType;
    int strength, defense, luck, speed;
    System.Random rand = new System.Random();


    public Item (int type, int level)
    {
        itemType = (ItemType) type;
        generateStats(type, level);
    }
    public Item()
    {
        itemType = (ItemType)100;
        generateStats(100, 0);

    }

    public void generateStats(int type, int level)
    {
        if (type == 1)
        {
            defense = level * (rand.Next(85, 101) / 100);
            strength = level * (rand.Next(15, 21) / 100);
            luck = level * (rand.Next(30, 41) / 100);
            speed = 0;
            return;
        }
        if (type == 2)
        {
            defense = level * (rand.Next(100, 121) / 100);
            strength = level * (rand.Next(30, 36) / 100);
            luck = 0;
            speed = 0;
            return;
        }
        if (type == 3)
        {
            defense = level * (rand.Next(85, 106) / 100);
            strength = 0;
            luck = 0;
            speed = level * (rand.Next(30, 36) / 100);
            return;
        }
        if (type == 4)
        {
            defense = level * (rand.Next(30, 36) / 100);
            strength = 0;
            luck = 0;
            speed = level * (rand.Next(85, 101) / 100);
            return;
        }
        if (type == 5)
        {
            defense = 0;
            strength = level * (rand.Next(125, 151) / 100);
            luck = level * (rand.Next(70, 86) / 100);
            speed = 0;
            return;
        }
        if (type == 6)
        {
            defense = level * (rand.Next(1, 101) / 100);
            strength = level * (rand.Next(1, 101) / 100);
            luck = level * (rand.Next(1, 101) / 100);
            speed = level * (rand.Next(1, 101) / 100);
            return;
        }
        if (type == 7)
        {
            //Scroll work here.  Unfinished, may not be implemented
            return;
        }
        defense = 0;
        strength = 0;
        luck = 0;
        speed = 0;
    }

    public Boolean Equals(Item CompareTo)
    {
        
        if (this.itemType == CompareTo.itemType 
            && this.defense == CompareTo.defense 
            && this.strength == CompareTo.strength 
            && this.luck == CompareTo.luck 
            && this.speed == CompareTo.speed)
        {
            return true;
        }
        return false;
    }
}
