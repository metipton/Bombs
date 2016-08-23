using UnityEngine;
using System.Collections;


public class ColorFade : MonoBehaviour
{
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