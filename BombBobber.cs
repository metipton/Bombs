using UnityEngine;
using System.Collections;
    // This script is attached to the spawned bombs at the beginning of the scene.  It just causes them to bob up at down to look cool.
public class BombBobber : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * .0007f * Mathf.Sin(2*Time.realtimeSinceStartup));
    }
}
