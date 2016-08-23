using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TimeDestroy : MonoBehaviour {
    public GameObject explosion; // blow up thangs (particle system)
    public GameObject explosionCloud;
    public GameObject CubeExplosion; // replacing cubes with crumbling cubes
    public Transform playerShot; // transform for positioning when raycasting to check for collisions
    public Rigidbody Playerkilled; // Rigidbody we are applying the explosion force to.
    public GameObject playerOnFire;// These two game objects are for finding the child particle system of player
    public GameObject FireSystem;// and then enabling once the player is killed
    public GameObject whitesmoke;
    public static bool isPlayerAlive = true;


    private float timeLeft = 4.5f;
	// Use this for initialization
	void Start()
    {
        FireSystem = playerOnFire.transform.Find("Fiery").gameObject;
        Playerkilled = GetComponent<Rigidbody>();
    }
	
	// This is a 4 second time to have bombs blow up.
	void Update ()
    {
        //sets time on instantiated object(dropped bomb) which explodes after 4 seconds
        timeLeft -= Time.deltaTime;
        if ( timeLeft <= 0)
        {
            CastAtPlayer();
            Casting(Vector3.forward); 
            Casting(Vector3.back);
            Casting(Vector3.left);
            Casting(Vector3.right);
            Instantiate(explosion, transform.position, transform.rotation); // graphic for explosion
            Destroy(this.gameObject, 0f); //removes instantiated bomb
            Bomb_Pickup.bombcount += 1;
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Cloud"))
        {
            timeLeft = timeLeft - 4.5f;
        }
    }

    void CastAtPlayer()
    {
        RaycastHit hit;
        Vector3 direction = -transform.position + playerShot.position;
        Ray landingRay = new Ray(transform.position, direction);
        if (Physics.Raycast(landingRay, out hit, (.2f + (PowerPick.PowerUpLevel * .2f))))
        {
            if (hit.collider.tag == ("Player"))
            {
                FireSystem.SetActive(true);
                Debug.Log("you dead");
                isPlayerAlive = false;
                Movement.nav.enabled = false;
                Playerkilled.AddExplosionForce(100f, transform.position, 0f, 100f);
            }
        }
    }

    void Casting(Vector3 direction) // Casts a ray in the forward direction to interact with cubes
    {
        Vector3 BombPosition = transform.position;
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, direction);
        float directionalSign;// used to either add or subtract from vector based on vector direction

        if (direction == Vector3.forward || direction == Vector3.right)
        {
            directionalSign = 1.0f;
        }
        else if(direction == Vector3.left || direction == Vector3.back)
        {
            directionalSign = -1.0f;
        }
        else
        {
            directionalSign = 1.0f;
        }

        if (Physics.Raycast(landingRay, out hit, (.2f + (PowerPick.PowerUpLevel * .2f))))//casts ray to intersect collider
        {
            Debug.Log("1");
            if (hit.collider.tag == ("DestructibleCube") && (direction == Vector3.forward ||direction == Vector3.back)) //checks for if raycast hits collider with tag 
            {
                for (float i = 0; i <= hit.distance + .2f; i += 0.2f)//instantiates explosion cloud from bomb to end of ray
                {
                    BombPosition.z = transform.position.z + (directionalSign*i);
                    Instantiate(whitesmoke, BombPosition, Quaternion.identity);
                }
                Instantiate(CubeExplosion, hit.collider.gameObject.transform.position, Quaternion.identity); //replaces gameobject with a fragmented gameobject to explose
                hit.collider.gameObject.SetActive(false); //deactivates original gameobject
            }
            else if (hit.collider.tag == ("DestructibleCube") && (direction == Vector3.left || direction == Vector3.right)) //checks for if raycast hits collider with tag 
            {
                for (float i = 0; i <= hit.distance + .2f; i += 0.2f)//instantiates explosion cloud from bomb to end of ray
                {
                    BombPosition.x = transform.position.x + (directionalSign * i);
                    Instantiate(whitesmoke, BombPosition, Quaternion.identity);
                }
                Instantiate(CubeExplosion, hit.collider.gameObject.transform.position, Quaternion.identity); //replaces gameobject with a fragmented gameobject to explose
                hit.collider.gameObject.SetActive(false); //deactivates original gameobject
            }

            else if (hit.collider.tag == ("Cube")) //checks for if raycast hits collider with tag Cube. Prevents casting explosion in pillars
            {
                return;
            }

            else if (hit.collider.tag == ("Wall") && (direction == Vector3.forward || direction == Vector3.back))
            {
                for (float i = 0; i <= hit.distance; i += 0.2f)//instantiates explosion cloud from bomb to end of ray
                {
                    BombPosition.z = transform.position.z + (directionalSign * i);
                    Instantiate(whitesmoke, BombPosition, Quaternion.identity);
                }
            }
            else if (hit.collider.tag == ("Wall") && (direction == Vector3.left || direction == Vector3.right))
            {
                for (float i = 0; i <= hit.distance; i += 0.2f)//instantiates explosion cloud from bomb to end of ray
                {
                    BombPosition.x = transform.position.x + (directionalSign * i);
                    Instantiate(whitesmoke, BombPosition, Quaternion.identity);
                }
            }
            else if (hit.collider.tag == ("Dropped Bomb") && (direction == Vector3.forward || direction == Vector3.back))
            {
                for (float i = 0; i <= hit.distance+ .2f; i += 0.2f) //instantiates explosion cloud from bomb to end of ray
                {
                    BombPosition.z = transform.position.z + (directionalSign * i);
                    Instantiate(whitesmoke, BombPosition, Quaternion.identity);
                }
            }
            else if (hit.collider.tag == ("Dropped Bomb") && (direction == Vector3.left || direction == Vector3.right))
            {
                for (float i = 0; i <= hit.distance+.2f; i += 0.2f)//instantiates explosion cloud from bomb to end of ray
                {
                    BombPosition.x = transform.position.x + (directionalSign * i);
                    Instantiate(whitesmoke, BombPosition, Quaternion.identity);
                }

            }

            else
            {
                for (float i = 0; i <= hit.distance; i += 0.2f)//instantiates explosion cloud from bomb to end of ray
                {
                    BombPosition.x = transform.position.x + (directionalSign * i);
                    Instantiate(whitesmoke, BombPosition, Quaternion.identity);
                }
            }
        }
        else if (direction == Vector3.forward || direction == Vector3.back)
        {
            for (float i = 0f; i <= .2f * PowerPick.PowerUpLevel +.2f; i += .2f)
            {
                BombPosition.z = transform.position.z + directionalSign * i;
                Instantiate(whitesmoke, BombPosition, Quaternion.identity);
            }
        }
        else
        {
            for (float i = 0f; i <= .2f * PowerPick.PowerUpLevel + .2f; i += .2f)
            {
                BombPosition.x = transform.position.x + directionalSign * i;
                Instantiate(whitesmoke, BombPosition, Quaternion.identity);
            }
        }

    }

}



