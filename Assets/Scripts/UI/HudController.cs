using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{

    private InventoryUI inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponentInChildren<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Open Inventory")){
            inventory.Display();
        }
    }
}
