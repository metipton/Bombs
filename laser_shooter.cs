using UnityEngine;
using System.Collections;

public class laser_shooter : MonoBehaviour {
    
    // This script is attached to the player game object.  It will draw a red laser line from the gun player barrel in the direction of where
    // the laser attached to the right controller is pointing.  This will be used to shoot other players later.

    public Transform GunBarrelEnd;
    private LineRenderer laserline; //A line renderer is a component attached to the player gameobjects.  Draws lines.

	void Awake ()
    {
        laserline = GetComponent<LineRenderer>();
        laserline.SetWidth(.005f, .005f);
	}

    void Update()
    {
        lasershooter();
    }

    void lasershooter ()
    {
        if (LaserPointer.IsRightTrigDown)
        {
            RaycastHit hit;
            GunBarrelEnd = this.gameObject.transform.GetChild(1);
            Ray shootingRay = new Ray(GunBarrelEnd.position, LaserPointer.laserhitpoint - GunBarrelEnd.position);
            if (Physics.Raycast(shootingRay, out hit, 3f))
            {
                Vector3 laserpoint = hit.point;
                laserpoint.y = .6f;
                laserline.SetPosition(0, GunBarrelEnd.position); //Draws line from end of gun barrel to x and z of laser hit point.  Maintains y.
                laserline.SetPosition(1, laserpoint);
            }
        }
        else
        {
            laserline.SetPosition(0, Vector3.zero); // this stops the line from being drawn when player is not holding down right trigger
            laserline.SetPosition(1, Vector3.zero);
        }
    }
}
