using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrantSystem : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject trigger2;
    [SerializeField] private bool isShooting;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] public bool done;
    

    public void Shoot()
    {
        if (!isShooting)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    private void Update()
    {
        useHydrant();
        if (done)
        {
            trigger2.SetActive(false);
        }
    }

    private void useHydrant()
    {
        if (isShooting)
        {
            particle.Play();
            trigger.SetActive(true);
            trigger2.SetActive(false);
            done = false;
        }
        else
        {
            particle.Stop();
            trigger.SetActive(false);
            trigger2.SetActive(true);
        }
    }
}
