using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public string spawnLocName = "SpawnLocation";
    public GameObject spawnLoc;

    new private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spawnLoc = GameObject.Find(spawnLocName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     To be called when the player dies
     Handles killing and respawning the player
     */
    public void Die(){
        transform.position = spawnLoc.transform.position;
        rigidbody.velocity = Vector3.zero;
    }


}
