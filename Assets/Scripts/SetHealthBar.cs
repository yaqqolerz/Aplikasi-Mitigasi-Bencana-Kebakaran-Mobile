using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SetHealthBar : MonoBehaviour
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private Image healthbar;
    [SerializeField] private Image Staminabar;

    // Update is called once per frame
    void Update()
    {
        SetHealth();
        SetStamina();
    }

    private void SetHealth()
    {
        healthbar.fillAmount = player.HealthPoint / 100f;
    }
    private void SetStamina()
    {
        Staminabar.fillAmount = player.Stamina / 100f;
    }
}
