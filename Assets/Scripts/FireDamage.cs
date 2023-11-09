using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FireDamage : MonoBehaviour
{
    [Header("Fire System Core")]
    [SerializeField] private FirstPersonController player;
    [SerializeField] private bool extinguishable = false;
    [SerializeField] private bool burning = false;
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private ParticleSystem smokeParticle;
    [SerializeField] private HydrantSystem hydrantControl;
    [Header("Extinguishable Fire Properties")]
    [SerializeField] private float fireHp = 100f;
    [SerializeField] public bool extinguished;
    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            burning = true;
        }
        else if (other.CompareTag("ExtTrigger"))
        {
            extinguished = true;
        }
        else if (other.CompareTag("ExtTrigger2"))
        {
            extinguished = false;
            hydrantControl.done = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            burning = false;
        }
    }

    private void Update()
    {
        if (burning)
        {
            //player.HealthPoint -= 10f * Time.deltaTime;
            player.dOTtimer = 2f;
            player.isBurning = true;
        }

        if (extinguished && extinguishable)
        {
            if(fireParticle != null && smokeParticle != null)
            {
                fireHp -= 20f * Time.deltaTime;
                fireParticle.startSize -= 0.5f * Time.deltaTime;
                smokeParticle.startSize -= 0.5f * Time.deltaTime;
                //ParticleSystem.MainModule mainModule = fireParticle.main;
                //mainModule.startSize = new ParticleSystem.MinMaxCurve(mainModule.startSize.constant - 0.5f * Time.deltaTime);
                //ParticleSystem.MainModule mainModule2 = smokeParticle.main;
                //mainModule.startSize = new ParticleSystem.MinMaxCurve(mainModule2.startSize.constant - 0.5f * Time.deltaTime);
                if (fireHp <= 0f)
                {
                    fireParticle.Stop();
                    smokeParticle.Stop();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
