using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
        if (onCooldown == true)
        {
            timebetweenbombs -= Time.deltaTime;
            if (timebetweenbombs < 0)
            {
                onCooldown = false;
                timebetweenbombs = .5f;

            }

        }


        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        // checks if trigger pulled, you have bombs in inventory, and not on cool down

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && BombColliderTracker.isColliding)
        {
            Destroy(BombColliderTracker.CollidedBomb, 0f);
            BombColliderTracker.BombsDropped.Remove(BombColliderTracker.CollidedBomb);
            Bomb_Pickup.bombcount += 1;
            if (BombColliderTracker.BombsDropped.Count == 0) 
            {
                BombColliderTracker.isColliding = false;
            }
        }
        else if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && Bomb_Pickup.bombcount > 0 && onCooldown != true)
        {
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