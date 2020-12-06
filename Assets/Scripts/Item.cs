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
    //Scroll = 7 = "Scroll", //Unimplemented.

    //Using the Unspecified as a way to test if an Item is 'empty'.
    Unspecified = 100
}

public class Item
{
    
    public static int types = 6;

    

    public ItemType itemType;
    static Item emptyItem = new Item();
    public int strength, defense, luck, level;
    System.Random rand = new System.Random();


    public Item (int level, int type)
    {
        itemType = (ItemType) type;
        this.level = level;
        generateStats(level, type);
    }
    public Item()
    {
        itemType = (ItemType)100;
        generateStats(0, 100);

    }

    public override string ToString()
    {
        string output = "";

        if ((int)itemType != 100)
        {
            String type = "";
            switch ((int)itemType)
            {
                case 1:
                    type = " Helm";
                    break;
                case 2:
                    type = " Shirt";
                    break;
                case 3:
                    type = " Pants";
                    break;
                case 4:
                    type = " Boots";
                    break;
                case 5:
                    type = " Sword";
                    break;
                case 6:
                    type = " Amulet";
                    break;
            }
            output += "L" + level + type + " ";
            output += "+" + this.strength + " Str";
            output += ", +" + this.defense + " Def";
        }
        return output;
    }

    public void generateStats(int level, int type)
    {
        if (type == 1)
        {
            
            defense = (int)(level * ((float)rand.Next(85, 101) / 100));
            strength = (int)(level * ((float)rand.Next(15, 21) / 100));
            luck = (int)(level * ((float)rand.Next(30, 41) / 100));
            return;
        }
        if (type == 2)
        {
            defense = (int)(level * ((float)rand.Next(100, 121) / 100));
            strength = (int)(level * ((float)rand.Next(30, 36) / 100));
            luck = 0;
            return;
        }
        if (type == 3)
        {
            defense = (int)(level * ((float)rand.Next(85, 106) / 100));
            strength = (int)(level * ((float)rand.Next(40, 56) / 100));
            luck = 0;
            return;
        }
        if (type == 4)
        {
            defense = (int)(level * ((float)rand.Next(30, 36) / 100));
            strength = 0;
            luck = 0;
            return;
        }
        if (type == 5)
        {
            defense = 0;
            strength = (int)(level * ((float)rand.Next(125, 151) / 100));
            luck = (int)(level * ((float)rand.Next(70, 86) / 100));
            return;
        }
        if (type == 6)
        {
            defense = (int)(level * ((float)rand.Next(1, 101) / 100));
            strength = (int)(level * ((float)rand.Next(1, 101) / 100));
            luck = (int)(level * ((float)rand.Next(1, 101) / 100));
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
    }

    public Boolean Equals(Item CompareTo)
    {
        
        if (this.itemType == CompareTo.itemType 
            && this.defense == CompareTo.defense 
            && this.strength == CompareTo.strength 
            && this.luck == CompareTo.luck)
        {
            return true;
        }
        return false;
    }
}
