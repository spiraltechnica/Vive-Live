using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class oscManager : MonoBehaviour {

    public SteamVR_TrackedObject leftTrackedObj;
    public SteamVR_TrackedObject rightTrackedObj;
    public SteamVR_TrackedController leftTrackedCont;
    public SteamVR_TrackedController rightTrackedCont;

    // Use this for initialization
    void Start () {
        OSCHandler.Instance.Init(); //init OSC
    }
    
    // c#
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    
    // Update is called once per frame
    void Update () {
        //Send a single float value to a server 
       
       // OSCHandler.Instance.SendMessageToClient("test", "address/folder", orientationAngle);

        //Send a list of object values. 
        //Note: you can send whatever values as a combination of floats, ints 
        //strings, bytes and any type allowed by UnityOSC 
        List<object> values = new List<object>();
        values.AddRange(new object[]{1.0f, 30.0f});
        // OSCHandler.Instance.SendMessageToClient("test", "address/folder", values); 



        SteamVR_Controller.Device rightDevice = SteamVR_Controller.Input((int)rightTrackedObj.index);
        SteamVR_Controller.Device leftDevice = SteamVR_Controller.Input((int)leftTrackedObj.index);
        Vector3 rightPos = rightDevice.transform.pos;
        Vector3 leftPos = leftDevice.transform.pos;
        Quaternion rightRot = rightDevice.transform.rot;
        Quaternion leftRot = leftDevice.transform.rot;

        /* float minDistance = 1f;

         if (Vector3.Distance(rightPos, main.transform.position) <= minDistance)
         {
             speed = map(Vector3.Distance(rightPos, main.transform.position), minDistance, 0f, 0.1f, 0.5f);
             Debug.Log("Distance Right:" + Vector3.Distance(rightPos, gameObject.transform.position).ToString());
             Debug.Log("Speed Right:" + speed.ToString());

         }*/

        OSCHandler.Instance.SendMessageToClient("Live", "/vc1/x", rightPos.x);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc1/y", rightPos.y);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc1/z", rightPos.z);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc1/rx", rightRot.x);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc1/ry", rightRot.y);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc1/rz", rightRot.z);

        OSCHandler.Instance.SendMessageToClient("Live", "/vc2/x", leftPos.x);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc2/y", leftPos.y);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc2/z", leftPos.z);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc2/rx", leftRot.x);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc2/ry", leftRot.y);
        OSCHandler.Instance.SendMessageToClient("Live", "/vc2/rz", leftRot.z);
    }

    private void OnEnable()
    {

        rightTrackedCont.TriggerClicked += HandleTriggerClicked;
        leftTrackedCont.TriggerClicked += HandleTriggerClicked;

        rightTrackedCont.TriggerUnclicked += HandleTriggerUnclicked;
        leftTrackedCont.TriggerUnclicked += HandleTriggerUnclicked;

        rightTrackedCont.Gripped += HandleGripped;
        leftTrackedCont.Gripped += HandleGripped;

        rightTrackedCont.Ungripped += HandleUngripped;
        leftTrackedCont.Ungripped += HandleUngripped;

    }

    private void OnDisable()
    {
        rightTrackedCont.TriggerClicked -= HandleTriggerClicked;
        leftTrackedCont.TriggerClicked -= HandleTriggerClicked;
        rightTrackedCont.TriggerUnclicked -= HandleTriggerUnclicked;
        leftTrackedCont.TriggerUnclicked -= HandleTriggerUnclicked;


        rightTrackedCont.Gripped -= HandleGripped;
        leftTrackedCont.Gripped -= HandleGripped;

        rightTrackedCont.Ungripped -= HandleUngripped;
        leftTrackedCont.Ungripped -= HandleUngripped;
    }

    private void HandleGripped(object sender, ClickedEventArgs e)
    {

        if (e.controllerIndex == rightTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc1/gripped", 1.0f);
        }
        if (e.controllerIndex == leftTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc2/gripped", 1.0f);
        }
    }

    private void HandleUngripped(object sender, ClickedEventArgs e)
    {

        if (e.controllerIndex == rightTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc1/gripped", 0.0f);
        }
        if (e.controllerIndex == leftTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc2/gripped", 0.0f);
        }
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {

        if(e.controllerIndex == rightTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc1/trigger", 1.0f);
        }
        if (e.controllerIndex == leftTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc2/trigger", 1.0f);
        }
    }

    private void HandleTriggerUnclicked(object sender, ClickedEventArgs e)
    {

        if (e.controllerIndex == rightTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc1/trigger", 0.0f);
        }
        if (e.controllerIndex == leftTrackedCont.controllerIndex)
        {
            OSCHandler.Instance.SendMessageToClient("Live", "/vc2/trigger", 0.0f);
        }
    }
}



