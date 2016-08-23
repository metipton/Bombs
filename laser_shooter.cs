using UnityEngine;
using System.Collections;

public class laser_shooter : MonoBehaviour {

    public Transform GunBarrelEnd;
    private LineRenderer laserline;


	void Awake () {

        laserline = GetComponent<LineRenderer>();
        laserline.SetWidth(.005f, .005f);
	}

    void Update()
    {
        lasershooter();
    }


    void lasershooter ()
    {
        if (LaserPointer.IsRightTrigDown == true)
        {
            RaycastHit hit;
            GunBarrelEnd = this.gameObject.transform.GetChild(1);
            Ray shootingRay = new Ray(GunBarrelEnd.position, LaserPointer.laserhitpoint - GunBarrelEnd.position);
            if (Physics.Raycast(shootingRay, out hit, 3f))
            {
                Vector3 laserpoint = hit.point;
                laserpoint.y = .6f;
                laserline.SetPosition(0, GunBarrelEnd.position);
                laserline.SetPosition(1, laserpoint);
            }
        }
        else
        {
            laserline.SetPosition(0, Vector3.zero);
            laserline.SetPosition(1, Vector3.zero);
        }

        


    }
}
