using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombColliderTracker : MonoBehaviour
{
    //This script is attached to the player game object.  It contains logic to test whether a player is within the collider for a bomb thas been dropped.
    // It will then control booleans that will be used in another script for whether or not to pick up the bomb gameobject that is already on the 
    // ground or to drop a new one.
    public static bool isColliding = false; //boolean to track whether character is on bomb or not.  Will be used to check if player should drop or pick up the bomb
    public static GameObject CollidedBomb;
    public static List<GameObject> BombsDropped = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dropped Bomb")
        {
            BombsDropped.Add(other.gameObject);
            isColliding = true;
            CollidedBomb = BombsDropped[BombsDropped.Count-1];
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dropped Bomb")
        {
            BombsDropped.Remove(other.gameObject);
            Debug.Log(BombsDropped.Count);
            if(BombsDropped.Count == 0)
            {
                isColliding = false;
            }
        }
    }
}