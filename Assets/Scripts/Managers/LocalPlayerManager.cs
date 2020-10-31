using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
A class for tracking who the local player's character is
Should be attached to all player characters
*/
public class LocalPlayerManager : MonoBehaviourPun
{

    public static GameObject LocalPlayerCharacter;
    public bool IsLocalPlayerCharacter{
        get{
            return gameObject == LocalPlayerCharacter;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Character spawning...");
        if(photonView.IsMine) {
            // ESTABLISH SELF AS THE LOCAL CHARACTER
            LocalPlayerManager.LocalPlayerCharacter = gameObject;
            Debug.Log(LocalPlayerCharacter);

            // ONLY ENABLE VIEW and INTERACT UI ON THE LOCAL CHARACTER
            transform.Find("Main Camera").gameObject.SetActive(true);
            transform.Find("InteractArea").gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
