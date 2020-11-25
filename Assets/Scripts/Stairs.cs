using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //Roll Random Number and load a room from switch case
            int RoomRoll = Random.Range(1, 4);
            print("Player has reached stairs, Rolling for new dungeon room: " + RoomRoll);
            switch (RoomRoll)
            {
                case 1:
                    SceneManager.LoadScene("Room1", LoadSceneMode.Single);
                    break;
                case 2:
                    SceneManager.LoadScene("Room2", LoadSceneMode.Single);
                    break;
                case 3:
                    SceneManager.LoadScene("Room3", LoadSceneMode.Single);
                    break;
                case 4:
                    SceneManager.LoadScene("Room4", LoadSceneMode.Single);
                    break;

            }
        }
    }
    //<Allen>

}
