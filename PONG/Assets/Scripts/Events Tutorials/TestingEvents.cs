using System; // Add to script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestingEvents : MonoBehaviour
{
    public event EventHandler<OnSpacePressedEventsArgs> OnSpacePressed;

    public class OnSpacePressedEventsArgs : EventArgs
    {
        public int spaceCount;
    }

    public event TestEventDelegate OnFloatEvent;
    public delegate void TestEventDelegate(float f);

    public event Action<bool, int> OnActionEvent;

    public UnityEvent OnUnityEvent;

    private int spaceCount;

    // Start is called before the first frame update
    void Start()
    {
        OnSpacePressed += Testing_OnSpacePressed;
    }

    private void Testing_OnSpacePressed(object sender, EventArgs e)
    {
      //  Debug.Log("Space!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        //   if(OnSpacePressed != null) OnSpacePressed(this, EventArgs.Empty);
            spaceCount++;
             OnSpacePressed?.Invoke(this, new OnSpacePressedEventsArgs { spaceCount = spaceCount});

            OnFloatEvent?.Invoke(5f);

            OnActionEvent?.Invoke(true, 10);

            OnUnityEvent?.Invoke();
        }

    }
}
