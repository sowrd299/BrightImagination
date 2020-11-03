﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A class for UI's that open up on the HUD
*/
public class HudUI : MonoBehaviour
{
    private bool _status;
    protected bool status{
        get{
            return _status;
        }
        set{
            if(value) gameObject.SetActive(value);
            _status = value;
        }
    }
    // Start is called before the first frame update
    protected void Start()
    {
        status = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        if(!status) gameObject.SetActive(status);
    }
    public void Display() {
        status = true;
    }

    public void Clear() {
        status = false;
    }
}
