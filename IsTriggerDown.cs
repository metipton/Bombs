using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class IsTriggerDown : MonoBehaviour
{
    public static bool movementTracker = false;
    SteamVR_TrackedObject trackedObj;
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();


    }


    void FixedUpdate()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.TouchPad))
        {
            movementTracker = true;
  
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.TouchPad))
        {
            movementTracker = false;

        }
    }
}
