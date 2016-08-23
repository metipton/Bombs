using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    //This script is attached to the player game object.  It tells the NavMeshAgent component to set its destination for the flag when the 
    // player is alive.  It also has the player rotate in the direction where the laser from the right controller is pointing.  Still working on 
    // what to do with the player once he is killed.

    Transform flag;
    public static UnityEngine.NavMeshAgent nav;

	void Awake() {
        flag = GameObject.FindGameObjectWithTag("Flag").transform;
        nav = GetComponent<UnityEngine.NavMeshAgent>();
	}
	
	void Update ()
    {
        if (TimeDestroy.isPlayerAlive)
        {
            NavWhenAlive();
        }
	}

    void playerRotator()
    {
        Vector3 lookPos = LaserPointer.laserhitpoint - transform.position;
        lookPos.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }

    void NavWhenAlive()
    {
        nav.SetDestination(flag.position);
        nav.updateRotation = false;
        playerRotator();
        if (Vector3.Distance(this.gameObject.transform.position, flag.position) <= .001)
        {
            nav.Stop();
        }
    }
}
