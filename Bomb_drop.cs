using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This script is attached to the left controller.  It will detect input from the controller and will drop a bomb if not on cooldown and 
// not standing on top of another bomb.

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Bomb_drop : MonoBehaviour
{

    SteamVR_TrackedObject trackedObj;
    public Transform playerPos;
    public GameObject bomb;

    private float timebetweenbombs = .5f;
    private bool onCooldown = false;
    Vector3 upshiftVector;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        // Tracker to manage cooldown for dropping bombs to .5 seconds
        if (onCooldown)
        {
            timebetweenbombs -= Time.deltaTime;
            if (timebetweenbombs < 0)
            {
                onCooldown = false;
                timebetweenbombs = .5f;
            }
        }

        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && BombColliderTracker.isColliding)
        {   // This code checks if you are still standing on a bomb that you dropped and will pick it up instead of putting a second one down
            Destroy(BombColliderTracker.CollidedBomb, 0f);
            BombColliderTracker.BombsDropped.Remove(BombColliderTracker.CollidedBomb);
            Bomb_Pickup.bombcount += 1;
            if (BombColliderTracker.BombsDropped.Count == 0) 
            {
                BombColliderTracker.isColliding = false;
            }
        }
        else if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && Bomb_Pickup.bombcount > 0 && onCooldown != true)
        {   // checks if trigger pulled, you have bombs in inventory, and not on cool down
            // upshift is so that bombs spawn floating slightly in the air
            upshiftVector = playerPos.position;
            upshiftVector.y = .65f;
            Instantiate(bomb, upshiftVector, Quaternion.identity);
            Bomb_Pickup.bombcount -= 1;
            onCooldown = true;
            timebetweenbombs = .5f;
        }
    }
}