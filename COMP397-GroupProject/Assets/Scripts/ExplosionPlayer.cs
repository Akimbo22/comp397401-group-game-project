using UnityEngine;

public class ExplosionPlayer : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private bool hasStarted = false;

    void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (!hasStarted)
        {
            particleSystem.Play();
            hasStarted = true;
        }
    }
}
