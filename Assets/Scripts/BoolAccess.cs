using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BoolAccess : MonoBehaviour
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private bool boolstate;
    // Start is called before the first frame update
    void Start()
    {
        boolstate = player.m_IsWalking;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Stamina <= 0)
        {
            boolstate = true;
        }
        player.m_IsWalking = boolstate;
    }

    public void enableBool()
    {
        if(boolstate && player.Stamina>=0)
        {
            boolstate = false;
        }
        else
        {
            boolstate = true;
        }
    }
}
