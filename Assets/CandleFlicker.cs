using UnityEngine;

public class CandleFlicker : MonoBehaviour
{

    public float maxIntensity = 2.0f;

    public float minIntensity = 0.8f;

    public float flickerSpeed = 5.0f;

    private Light candleLight;

    private float randomOffset;

    void Start()
    {
        candleLight = GetComponent<Light>();

        randomOffset = Random.Range(0f, 100f);
        //picks a random decimal number between 0 and 100 to shift the candles poistion on the 
        //noise graph
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed + randomOffset, 0f);

        //time.time is elapsed time since game started.

        candleLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        //lerp gets value bet 0 percent and 100 percent, i give it a bottom and top limit
        // the intensity i decided for both, makes 0.8, the min = 0 percent, and 2.0 the max = 100 percent

    }
}
