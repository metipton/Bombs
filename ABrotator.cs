using UnityEngine;
using System.Collections;

// This script is attached to my powerup pick up objects.  It rotates the transform of the object so it looks cool.

public class ABrotator : MonoBehaviour {

	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
