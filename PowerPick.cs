using UnityEngine;
using System.Collections;

public class PowerPick : MonoBehaviour
{
    //This script is attached to the player game object and is used to track the pickup of power ups.

    public static int PowerUpLevel;

    void Awake()
    {
        PowerUpLevel = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerPickUp"))
        {
            other.gameObject.SetActive(false);
            PowerUpLevel += 1;
            Debug.Log("PowerUp count is :" + PowerUpLevel);
        }
    }
}
