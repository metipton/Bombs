using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

    public float timeTilFade = 1.0f;
    

    void FixedUpdate()
    {
        timeTilFade -= Time.deltaTime;
        if (timeTilFade < 0)
        {  
            Destroy(this.gameObject, 0f);
        }
    }

}
