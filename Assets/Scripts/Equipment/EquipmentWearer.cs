using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EquipmentWearer : MonoBehaviourPun, IPunObservable
{

    public string equipmentDir = "Prefabs/Equipment";

    // tracks all equipment currently being worn
    protected HashSet<GameObject> allEquipment;
    private const string msgTerminator = "/msg";

    // Start is called before the first frame update
    void Start()
    {
        allEquipment = new HashSet<GameObject>();
        foreach(EquipmentController ec in GetComponentsInChildren<EquipmentController>()) {
            allEquipment.Add(ec.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    Call this to add equipment to this character
    */
    public void Equip(string equipmentName) {
        equip(equipmentName);
    }

    private void equip(string equipmentName) {
        if(!transform.Find(equipmentName)) {
            GameObject prefab = Resources.Load<GameObject>(equipmentDir + "/" + equipmentName) as GameObject;
            GameObject equipment = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            equipment.name = equipmentName; // must make sure it has the correct name
            equipment.transform.SetParent(transform);
            allEquipment.Add(equipment);
        }
    }

    // syncing list of equipment, so that new players can catch up
    // is not used by existing players who can just watch the RPC calls
    // TODO: consider having this replace RPC calls
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting){
            foreach(GameObject go in allEquipment) {
                stream.SendNext(go.name);
            }
            stream.SendNext(msgTerminator);
        }else{
            string name;
            while(true) {
                name = (string)stream.ReceiveNext();
                if(name == msgTerminator){
                    break;
                }
                equip(name);
            } 
        }
    }

}
