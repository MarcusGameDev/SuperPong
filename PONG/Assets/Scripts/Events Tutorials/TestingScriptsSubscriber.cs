using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScriptsSubscriber : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;

        testingEvents.OnFloatEvent += TestingEvents_OnFloatEvent;

        testingEvents.OnActionEvent += TestingEvents_OnActionEvent;
    }

    private void TestingEvents_OnActionEvent(bool e, int f)
    {
        Debug.Log(e + " + " + f);
    }

    private void TestingEvents_OnFloatEvent(float f)
    {
        Debug.Log("Float: " + f);
    }

    private void TestingEvents_OnSpacePressed(object sender, TestingEvents.OnSpacePressedEventsArgs e)
    {
        Debug.Log("Space!!!!!! " + e.spaceCount);
        TestingEvents testingEvents = GetComponent<TestingEvents>();
      //  testingEvents.OnSpacePressed -= TestingEvents_OnSpacePressed; // UnSubscribe from the event
    }

    public void TestingUnityEvent()
    {
        Debug.Log("TestingUnityEvent");
    }
}
