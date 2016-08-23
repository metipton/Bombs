using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Transform flag;
   
   public static UnityEngine.NavMeshAgent nav;
	// Use this for initialization
	void Awake() {
        flag = GameObject.FindGameObjectWithTag("Flag").transform;
        nav = GetComponent<UnityEngine.NavMeshAgent>();

	}
	
	// Update is called once per frame
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
