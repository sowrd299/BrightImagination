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

    void awake() {
        if(photonView.IsMine) {
            LocalPlayerManager.LocalPlayerCharacter = gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ONLY ENABLE VIEW and INTERACT UI ON THE LOCAL CHARACTER
        if(photonView.IsMine){
            transform.Find("Main Camera").gameObject.SetActive(true);
            transform.Find("InteractArea").gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
