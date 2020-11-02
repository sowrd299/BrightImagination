using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EquipmentWearer : MonoBehaviourPun
{

    public string equipmentDir = "Prefabs/Equipment";
    public List<GameObject> equipment;

    // Start is called before the first frame update
    void Start()
    {
        Equip("KoEyeE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    Call this to add equipment to this character
    */
    public void Equip(string equipmentName) {
        photonView.RPC("equip", RpcTarget.All, equipmentName);
    }

    [PunRPC]
    private void equip(string equipmentName, PhotonMessageInfo info) {
        if(!transform.Find(equipmentName)) {
            GameObject prefab = Resources.Load<GameObject>(equipmentDir + "/" + equipmentName) as GameObject;
            GameObject equipment = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            equipment.transform.SetParent(transform);
        }
    }
    
}
