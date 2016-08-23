using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
    // This script is attached to the CubeBlowUp game object.  This game object is a bunch of smaller cubes that represent the shards that
    // the larger destructible cube will break into when hit by raycast from the bomb explosion.  It causes the shards to disappear after a short
    //time.
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
