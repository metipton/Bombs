using UnityEngine;
using System.Collections;

public class BombBobber : MonoBehaviour
{

    void Update()
    {
        transform.Translate(Vector3.up * .0007f * Mathf.Sin(2*Time.realtimeSinceStartup));

    }
}
