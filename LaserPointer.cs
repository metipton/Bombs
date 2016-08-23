using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class LaserPointer : MonoBehaviour {

    public static Vector3 laserhitpoint;
    public static Transform shooterPos;
    public static bool IsRightTrigDown = false;

    private LineRenderer laserpointer;
    private SteamVR_TrackedObject rightcontroller;
    


    void Awake () {
        rightcontroller = GetComponent<SteamVR_TrackedObject>();
        laserpointer = GetComponent<LineRenderer>();
        laserpointer.SetWidth(.005f, .005f);
    }
	

	void Update ()
    { 
        Laserpoint();
        PlayerLaser();
	}

    void Laserpoint()
    {
        RaycastHit hit;
        Ray shootingRay = new Ray(rightcontroller.transform.position, rightcontroller.transform.forward);
        if (Physics.Raycast(shootingRay, out hit, 5f))
        {
            if (hit.collider.tag == ("Floor") || hit.collider.tag == ("Cube") || hit.collider.tag == ("Wall") || hit.collider.tag == ("DestructibleCube") || hit.collider.tag == ("Player"))
            {
                laserpointer.SetPosition(0, rightcontroller.transform.position);
                laserpointer.SetPosition(1, hit.point);
                laserhitpoint = hit.point; // point to be used to rotate the player
            }
        }
        else
        {
            Vector3 miss = rightcontroller.transform.position + 10 * rightcontroller.transform.forward;
            laserpointer.SetPosition(0, rightcontroller.transform.position);
            laserpointer.SetPosition(1, miss);
        }
        
    }

    void PlayerLaser() // this casts a ray from player in direction facing which will be used later to shoot laser bolts
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)rightcontroller.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.TouchPad)) // have weird issue where touchpad and trigger are switched.  Not sure why.
        {
            IsRightTrigDown = true;

        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.TouchPad)) // have weird issue where touchpad and trigger are switched.  Not sure why.
        {

            IsRightTrigDown = false;
        }
    }
}
