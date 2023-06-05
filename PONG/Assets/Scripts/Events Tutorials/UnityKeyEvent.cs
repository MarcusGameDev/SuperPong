
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityKeyEvent : MonoBehaviour
{
    public UnityEvent OnPressE; 

    public event EventHandler OnPressF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnPressE?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            OnPressF?.Invoke(this, EventArgs.Empty);
        }
    }
}
