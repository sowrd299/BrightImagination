using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    // THE INTERACTABLE THE INTERACTOR WILL INTERACT WITH
    // highlights only the current interactable
    private Interactable target;
    public Interactable Target{
        private set{
            target?.Unhighlight();
            target = value;
            target?.Highlight();
        }
        get{
            return target;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // TRACK INTERACABLES IN RANGE 
    void OnTriggerEnter2D(Collider2D other){
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable){
            this.Target = interactable;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable == this.Target){
            this.Target = null;
        }
    }


}
