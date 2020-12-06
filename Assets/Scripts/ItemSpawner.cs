using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allen
public class ItemSpawner : MonoBehaviour
{

    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;


    // Start is called before the first frame update
    void Start()
    {

    //Roll Random Number and load a room from switch case
    int ItemRoll = Random.Range(1, 4);
        switch (ItemRoll)
        {
            case 1:
            Instantiate(Spawn1, transform.position, transform.rotation);
            Destroy(gameObject);
            break;

            case 2:
            Instantiate(Spawn2, transform.position, transform.rotation);
            Destroy(gameObject);
            break;

            case 3:
            Instantiate(Spawn3, transform.position, transform.rotation);
            Destroy(gameObject);
            break;

            case 4:
            Instantiate(Spawn4, transform.position, transform.rotation);
            Destroy(gameObject);
            break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
//<Allen>