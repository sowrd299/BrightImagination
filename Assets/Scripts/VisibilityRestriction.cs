using System; // for Array.Index of
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class VisibilityRestriction : MonoBehaviourPun, IPunObservable
{

    // the time for which this restriction will last
    public float timeRestricted = 60;

    private bool restricted;
    private bool visibleToMe;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    /**
    Takes an array of the view ids of the players this object
        should be able to be seen by
    Should be called on ALL copies, specifically the owner
    Will not on its own deactivate any copies, to prevent missed messages
    */
    public void SetVisibility(int[] visibleTo) {
        visibleToMe = Array.IndexOf(visibleTo, LocalPlayerManager.ViewID) >= 0;

        // only the owner will run the timer, so everyone agrees
        if(photonView.IsMine) {
            restricted = true;
            StartCoroutine("TimeRestriction");
        }
    }

    // the actual time delay
    private IEnumerator TimeRestriction() {
        yield return new WaitForSeconds(timeRestricted);
        photonView.RPC("EndRestriction", RpcTarget.All);
    }

    // use RPC to wake up inactive copies when time ends
    [PunRPC]
    private void EndRestriction() {
        Debug.Log("Restricted vision ending");
        restricted = false;
        updateActive();
    }

    // tracks the current state for new copies
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting){
            stream.SendNext(restricted);
        } else {
            restricted = (bool)stream.ReceiveNext();
        }
        // this ensures "true" has been sent before dectivating
        updateActive(); 
    }

    /**
    Updates the active state of the object
    To be call IMEDIATELY AFTER sending/recieving data
    */
    private void updateActive(){
        Debug.Log("Restricted: " + restricted.ToString());
        gameObject.SetActive(!restricted || visibleToMe);
    }

}
