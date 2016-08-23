using UnityEngine;
using System.Collections;

public class PowerPick : MonoBehaviour
{
    public static int PowerUpLevel;
    // Use this for initialization
    void Awake()
    {
        PowerUpLevel = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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
