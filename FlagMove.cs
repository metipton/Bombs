using UnityEngine;
using System.Collections;

public class FlagMove : MonoBehaviour {

    public Transform controllerPos;
    Vector3 ControllerVector;

	void FixedUpdate () {
        if(IsTriggerDown.movementTracker == true)
        {
            ControllerVector.x = controllerPos.position.x;
            ControllerVector.z = controllerPos.position.z;
            ControllerVector.y = .55f;
            transform.position = ControllerVector ; 
        }
	
	}
}
