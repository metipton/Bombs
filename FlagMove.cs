using UnityEngine;
using System.Collections;

public class FlagMove : MonoBehaviour {

    // This script is attached to the flag game object.  It changes the position of the flag in the x and z directions when the trigger
    // on the left controller is held down to the x and z positions of the left controller transform.  (The flag is the destination for the 
    // NavMeshAgent component attached to the player object.  The player will always follow the flag and this is how we move our character around)  
    public Transform controllerPos;
    Vector3 ControllerVector;

	void FixedUpdate () {
        if(IsTriggerDown.movementTracker)
        {
            ControllerVector.x = controllerPos.position.x;
            ControllerVector.z = controllerPos.position.z;
            ControllerVector.y = .55f;
            transform.position = ControllerVector ; 
        }	
	}
}
