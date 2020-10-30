using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableDialog : Interactable
{

    public string dialog = "<b>Wizened One</b>\nHello Traveler! Welcome to Port Teviam! I believe you have many amazing adventures ahead of you; don't you?";
    public string canvasName = "Canvas";

    private DialogUI dialogUI;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        dialogUI = GameObject.Find(canvasName).GetComponentInChildren<DialogUI>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update(); 
    }

    public override void Interact(GameObject player) {
        dialogUI.Display(dialog);
    }

}
