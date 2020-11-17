using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

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
        GUI.Label(new Rect(100, 280, 100, 20), "HP/HP:");
        GUI.Label(new Rect(100, 300, 100, 20), "Attack: " + PlayerObject.strength);
        GUI.Label(new Rect(100, 320, 100, 20), "Defense: " + PlayerObject.defense);
        GUI.Label(new Rect(100, 340, 100, 20), "Gold: " + PlayerObject.gold);
    }
}
