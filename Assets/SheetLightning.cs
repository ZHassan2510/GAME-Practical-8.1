using UnityEngine;
using System.Collections;

public class SheetLightning : MonoBehaviour
{

    public float minWaitTime = 4.0f;

    public float maxWaitTime = 10f;
    //min and max wait times bet lightning strikes

    public float flashDuration = 0.1f;

    private Light lightningLight;

    void Start()
    {
        lightningLight = GetComponent<Light>();

        lightningLight.enabled = false;

        StartCoroutine(LightningLoop());

        //coroutine cause unlike a nomral method it can pause and resume later.
    }

    IEnumerator LightningLoop()
    {
        //ienumerator return type allows me to use yield return

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            //pauses coroutine for random number  of secs between my min and max, while paused game still goes.

            lightningLight.enabled = true;

            yield return new WaitForSeconds(flashDuration);
            //keeps lightning light on for duration of the strike

            lightningLight.enabled = false;
            //turns it off after strike.

            yield return new WaitForSeconds(0.08f);
            //waits a little before second flash

            lightningLight.enabled = true;
            //turns it one for quick second strike

            yield return new WaitForSeconds(flashDuration * 0.5f);
            //keeps second flash on for shorter amount of time

            lightningLight.enabled = false;
            //turns off the light and loop restarts.
        }

    }
}
