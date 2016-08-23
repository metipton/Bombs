using UnityEngine;
using System.Collections;

public class TimeForSmoke : MonoBehaviour
{
    //This script is attached to the explosion cloud game object.  Current "problem child" script. Renderers draw the skin for game objects.
    // The intention for this script is to have the explosion clouds fade instead of just disappearing.  The FadeOut() function is supposed to 
    //decrement the "a" value (the opacity) for the renderer attached to the children of the Explosion (cloud) game object until it is clear.  
    //Instead it just causes the game to crash.

   // public Renderer[] smokeFades;
    private float timeLeft=1.0f;

    void Start()
    {
       // smokeFades = GetComponentsInChildren<Renderer>();
    }

	void Update ()
    {
       // StartCoroutine(FadeOut());
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(this.gameObject, 0f); //removes instantiated smoke
        }
    }
   /* IEnumerator FadeOut()
    {
        for (float f = timeLeft; f >= 0; f -= 0.1f)
        {
            Debug.Log("1");
            foreach (Renderer smokeFade in smokeFades)
            {
                Debug.Log("2");
                Color opacity = smokeFade.material.color;
                opacity.a = f;
                smokeFade.material.color = opacity;
            }
            Debug.Log("3");
            yield return new WaitForSeconds(.1f);
        }     
    } */
}
