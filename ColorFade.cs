using UnityEngine;
using System.Collections;

public class ColorFade : MonoBehaviour
{   //This script is attached to dropped bombs game objects.  It will change the color of the attached light component(which gives the bomb the
    // appearence of a halo glow) on a timer.  As the bomb gets
    //closer to its explosion time, the color will Lerp( linearly interpolate) from green to yellow to red.
    public Light dropLight;

    private float timeGameStart;
   
    void Awake()
    {
        dropLight = this.gameObject.GetComponent<Light>();
        dropLight.color = Color.green;
        timeGameStart = 0f;   
    }

    void Update()
    {
        timeGameStart += Time.deltaTime;
        dropLight.color = Color.Lerp(Color.green, Color.red, timeGameStart/4.0f);       
    }
}