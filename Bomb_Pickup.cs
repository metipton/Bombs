using UnityEngine;
using System.Collections;

public class Bomb_Pickup : MonoBehaviour {

    public static int bombcount;
	// Use this for initialization
	void Awake () {
        bombcount = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Bomb"))
        {
            other.gameObject.SetActive(false);
            bombcount += 1;
            Debug.Log("Bomb count is :" + bombcount);
        }
    }
}
 