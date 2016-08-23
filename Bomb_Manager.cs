using UnityEngine;
using System.Collections;

public class Bomb_Manager : MonoBehaviour
{   // This script is attached to an empty gameobject and it controls the spawning of the destructible cubes, bomb pick up objects, and 
    // powerup pick up objects. This stupid array contains the possible starting point for spawned objects.  There is a shuffle script in here that
    // shuffles this array and that will pseudo randomize spawn locations when the game starts.

    public GameObject bombs;
    public GameObject Cubes;
    public GameObject PowerUp;

    //The following is an array of Vector3's for all possible spawn locations of the bombs on the board
    public Vector3[] spawnPosArray = new[] 
    {
                                       new Vector3(-1.0f,.65f,-1.2f), new Vector3(-1.0f,.65f,-1.0f),new Vector3(-1.0f,.65f,-.8f),
                                       new Vector3(-1.0f,.65f,-.6f),  new Vector3(-1.0f,.65f,-.4f), new Vector3(-1.0f,.65f,-.2f),
                                       new Vector3(-1.0f,.65f, 0f),   new Vector3(-1.0f,.65f,.2f),  new Vector3(-1.0f,.65f, .4f),
                                       new Vector3(-1.0f,.65f,.6f),   new Vector3(-1.0f,.65f,.8f),  new Vector3(-.8f,.65f,-1.2f),
                                       new Vector3(-.8f,.65f,-.8f),   new Vector3(-.8f,.65f,-.4f),  new Vector3(-.8f,.65f, 0f),
                                       new Vector3(-.8f,.65f,.4f),    new Vector3(-.8f,.65f,.8f),   new Vector3(-.6f,.65f,.6f),
                                       new Vector3(-.6f,.65f,-1.2f),  new Vector3(-.6f,.65f,-1.0f), new Vector3(-.6f,.65f,-.8f),
                                       new Vector3(-.6f,.65f,-.6f),   new Vector3(-.6f,.65f,-.4f),  new Vector3(-.6f,.65f,-.2f),
                                       new Vector3(-.6f,.65f,0f),     new Vector3(-.6f,.65f, .2f),  new Vector3(-.6f,.65f, .4f),
                                       new Vector3(-.6f,.65f,.8f),    new Vector3(-.6f,.65f,1.0f),  new Vector3(-.6f,.65f,1.2f),
                                       new Vector3(-.4f,.65f,-1.2f),  new Vector3(-.4f,.65f,-.8f),  new Vector3(-.4f,.65f,-.4f),
                                       new Vector3(-.4f,.65f,0f),     new Vector3(-.4f,.65f,.4f),   new Vector3(-.4f,.65f,.8f),
                                       new Vector3(-.4f,.65f,1.2f),
                                       new Vector3(-.2f,.65f,-1.2f),  new Vector3(-.2f,.65f,-1.0f), new Vector3(-.2f,.65f,-.8f),
                                       new Vector3(-.2f,.65f,-.6f),   new Vector3(-.2f,.65f,-.4f),  new Vector3(-.2f,.65f,-.2f),
                                       new Vector3(-.2f,.65f,0f),     new Vector3(-.2f,.65f, .2f),  new Vector3(-.2f,.65f,.4f),
                                       new Vector3(-.2f,.65f,.6f),    new Vector3(-.2f,.65f,.8f),   new Vector3(-.2f,.65f,1.0f),
                                       new Vector3(-.2f,.65f,1.2f),   new Vector3(0,.65f,-1.2f),    new Vector3(0,.65f,-.8f),
                                       new Vector3(0,.65f,-.4f),      new Vector3(0,.65f,0f),       new Vector3(0,.65f,.4f),
                                       new Vector3(0,.65f,.8f),       new Vector3(0,.65f,1.2f),
                                       new Vector3(1.0f,.65f,1.2f),   new Vector3(1.0f,.65f,1.0f),  new Vector3(1.0f,.65f,-.8f),
                                       new Vector3(1.0f,.65f,-.6f),   new Vector3(1.0f,.65f,-.4f),  new Vector3(1.0f,.65f,-.2f),
                                       new Vector3(1.0f,.65f,0),      new Vector3(1.0f,.65f,.2f),   new Vector3(1.0f,.65f, .4f),
                                       new Vector3(1.0f,.65f,.6f),    new Vector3(1.0f,.65f,.8f),   new Vector3(.8f,.65f,1.2f),
                                       new Vector3(.8f,.65f,-.8f),    new Vector3(.8f,.65f,-.4f),   new Vector3(.8f,.65f, 0f),
                                       new Vector3(.8f,.65f,.4f),     new Vector3(.8f,.65f,.8f),    new Vector3(.6f,.65f,.6f),
                                       new Vector3(.6f,.65f,-1.2f),   new Vector3(.6f,.65f,-1.0f),  new Vector3(.6f,.65f,-.8f),
                                       new Vector3(.6f,.65f,-.6f),    new Vector3(.6f,.65f,-.4f),   new Vector3(.6f,.65f,-.2f),
                                       new Vector3(.6f,.65f,0f),      new Vector3(.6f,.65f, .2f),   new Vector3(.6f,.65f, .4f),
                                       new Vector3(.6f,.65f,.8f),     new Vector3(.6f,.65f,1.0f),   new Vector3(.6f,.65f,1.2f),
                                       new Vector3(.4f,.65f,-1.2f),   new Vector3(.4f,.65f,-.8f),   new Vector3(.4f,.65f,-.4f),
                                       new Vector3(.4f,.65f,0f),      new Vector3(.4f,.65f,.4f),    new Vector3(.4f,.65f,.8f),
                                       new Vector3(.4f,.65f,1.2f),
                                       new Vector3(.2f,.65f,-1.2f),   new Vector3(.2f,.65f,-1.0f),  new Vector3(.2f,.65f,-.8f),
                                       new Vector3(.2f,.65f,-.6f),    new Vector3(.2f,.65f,-.4f),   new Vector3(.2f,.65f,-.2f),
                                       new Vector3(.2f,.65f,0f),      new Vector3(.2f,.65f, .2f),   new Vector3(.2f,.65f,.4f),
                                       new Vector3(.2f,.65f,.6f),     new Vector3(.2f,.65f,.8f),    new Vector3(.2f,.65f,1.0f),
                                       new Vector3(.2f,.65f,1.2f)
    };

    // Use this for initialization
    void Awake()
    {   //Shuffles the array
        Shuffle(spawnPosArray);
    }

    void Start()
    {
        //Spawns all the bombs at the beginning of the level
        for (int i = 0; i < 10; i++)
        {   // spawns the bombs
            Instantiate(bombs, spawnPosArray[i], Quaternion.identity);        
        }

        for (int i = 0; i < 61; i++)
        {  // spawns the destructible cubes
            Instantiate(Cubes, spawnPosArray[i], Quaternion.identity);
        }

        for (int i = 11; i < 21; i++)
        {   // spawns powerups
            Instantiate(PowerUp, spawnPosArray[i], Quaternion.identity);
        }
    }

    void Shuffle(Vector3[] a)
    {
        // Loops through array
        for (int i = a.Length - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overright when we swap the values
            Vector3 temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }
    }
}