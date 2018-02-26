using UnityEngine;
using System.Collections;
using System.Collections.Generic;
	
public class FancyLights: MonoBehaviour
{

    public float speedCap;
    public bool pulse = false;

    public Light lightSource;
    public float minLightIntensity = 0f;
	public float maxLightIntensity = 1f;
    private float minRange;
    private float maxRange;

    public Renderer emissionMaterial;  
    public float minEmission = 0f;
    public float maxEmission = 1f;


    public ParticleSystem particleSys;
    private Color emissionColor;
    private ParticleSystem.MinMaxCurve emissionRate;

    private float random;

    void Start()
	{
		random = Random.Range(0.0f, 65535.0f);

        if (lightSource != null)
        {
            float absVal = Mathf.Abs((lightSource.intensity - minLightIntensity) / (maxLightIntensity - minLightIntensity));
            minRange = lightSource.range - lightSource.range * absVal;
            maxRange = lightSource.range * (1 + absVal);
        }

        if (emissionMaterial != null)
            emissionColor = emissionMaterial.material.GetColor("_EmissionColor");

        if (particleSys != null)
            emissionRate = particleSys.emission.rate;
    }

	void Update()
	{
        float noise;
        if (!pulse)
		 noise = Mathf.PerlinNoise(random, Time.time*speedCap);
        else
         noise = Mathf.PingPong(Time.time * speedCap, 1);


        //Light
        if (lightSource != null)
        {
            lightSource.intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, noise);
            lightSource.range = Mathf.Lerp(minRange, maxRange, noise);
        }

        //Emission
        if (emissionColor != null)
        {
            if (!pulse)
                emissionMaterial.material.SetColor("_EmissionColor", Color.Lerp(emissionColor * Mathf.LinearToGammaSpace(minEmission),
                    emissionColor * Mathf.LinearToGammaSpace(maxEmission),
                    noise));
        }

        //Particles
        if (particleSys != null)
        {
            var emit = particleSys.emission;
            emit.rate = new ParticleSystem.MinMaxCurve(5 + emit.rate.constantMax + 20 * Time.deltaTime);
        }
    }
}