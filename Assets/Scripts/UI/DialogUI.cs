using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{

    private bool _status;
    private bool status{
        get{
            return _status;
        }
        set{
            if(value) gameObject.SetActive(value);
            _status = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!status) gameObject.SetActive(status);
    }

    /**
    To be called to display text
     */
    public void Display(string dialog) {
        status = true;
        transform.Find("Text").GetComponent<TMP_Text>().text = dialog;
    }

    public void Clear() {
        status = false;
    }

}
