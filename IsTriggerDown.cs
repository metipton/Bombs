using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class IsTriggerDown : MonoBehaviour
{   // Script is attached to the left controller. Script that controls booleans for whether or not the trigger on the left controller is held down.  Can definitely but merged with the flag
    // move script but don't want to deal with that right now.

    public static bool movementTracker = false;
    SteamVR_TrackedObject trackedObj;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.TouchPad)) // weird bug where the touchpad and trigger references have switched. Not sure why.
        {
            movementTracker = true;
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.TouchPad))
        {
            movementTracker = false;
        }
    }
}
