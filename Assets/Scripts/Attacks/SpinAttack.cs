using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
A script for attacks based on a certain amount of spinning at a certain speed
Deleates self after the spinning is over
*/
public class SpinAttack : MonoBehaviourPun
{

    public Vector3 totalRotation = new Vector3(0,0,-360);
    public float totalTime = 0.5f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spin
        transform.Rotate(totalRotation * Time.deltaTime / totalTime);    
        timer += Time.deltaTime;

        // disappear once timer is over
        if(timer > totalTime && photonView.IsMine){
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
