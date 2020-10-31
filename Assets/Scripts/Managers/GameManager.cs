using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

    public string prefabDir = "prefabs";
    public GameObject pcPrefab;
    public GameObject spawnLoc;

    // Start is called before the first frame update
    void Start()
    {

        // GO TO THE LOADING SCREEN IF WE AREN'T CONNECTED YET
        if(!PhotonNetwork.IsConnected) {
            SceneManager.LoadScene("Loading");
            return;
        }

        // SPAWNING IN THE FIRST PLAYER
        if(pcPrefab && spawnLoc && !LocalPlayerManager.LocalPlayerCharacter){
            PhotonNetwork.Instantiate(prefabDir + "/" + this.pcPrefab.name, spawnLoc.transform.position, spawnLoc.transform.rotation, 0);
        }else if(pcPrefab){
            Debug.Log("Spawn Location not set!");
        }else{
            Debug.Log("Player Character prefab is missing!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player other) {

    }

    public override void OnPlayerLeftRoom(Player other) {

    }

}
