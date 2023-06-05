using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    UnityKeyEvent unityKeyEvent;

    // Start is called before the first frame update
    void Start()
    {
        UnityKeyEvent unityKeyEvent = GetComponent<UnityKeyEvent>();
        unityKeyEvent.OnPressF += OnPressF;
    }

    void OnPressF(object sender, EventArgs e)
    {
        Debug.Log("Press F to pay respects");
    }

    public void OnPressE()
    {
        Debug.Log("E has been pressed!");
    }
}
