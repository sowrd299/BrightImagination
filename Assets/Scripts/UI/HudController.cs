using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{

    private HudUI[] uis;
    private InventoryUI inventory;

    private DialogUI dialog;
    public DialogUI Dialog{
        get{
            return dialog;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uis = GetComponentsInChildren<HudUI>();
        inventory = GetComponentInChildren<InventoryUI>();
        dialog = GetComponentInChildren<DialogUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Open Inventory")){
            inventory.Display();
        }
    }

    public void ClearAll(){
        foreach(HudUI ui in uis){
            ui.Clear();
        }
        
    }
}
