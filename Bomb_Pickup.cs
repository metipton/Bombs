using UnityEngine;
using System.Collections;

public class Bomb_Pickup : MonoBehaviour {
    //This script is attached to the Player game object.  It will detect a collision with a trigger collider attached to the bomb object and will
    //destroy the floating bomb and add 1 to the players bombcount.  That player can now drop one more bomb at a time.
    public static int bombcount;

	void Awake () {
        bombcount = 1;
	}
	
	// Update is called once per frame

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
 