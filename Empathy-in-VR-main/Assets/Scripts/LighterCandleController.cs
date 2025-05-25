using UnityEngine;

public class LighterCandleController : MonoBehaviour
{
    public ParticleSystem candleParticleSystem;
    public Collider candleCollider;

    void Start()
    {
        // Ensure both particle systems are stopped at the start
        if (candleParticleSystem != null)
        {
            candleParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == candleCollider)
        {
            ActivateCandle();
        }
    }

    void ActivateCandle()
    {
        // Play the candle's particles if not already playing
        if (!candleParticleSystem.isPlaying)
        {
            candleParticleSystem.Play();
        }
    }
}