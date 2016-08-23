using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombColliderTracker : MonoBehaviour
{

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