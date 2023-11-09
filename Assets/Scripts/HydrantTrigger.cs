using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrantTrigger : MonoBehaviour
{
    [Header("UI to Show")]
    [SerializeField] private GameObject useButon;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject ammoUI;
    [Header("Objects to Show and Hide")]
    [SerializeField] private GameObject onWall;
    [SerializeField] private GameObject onPlayer;
    [Header("Boolean")]
    [SerializeField] private bool interacted;

    private void OnTriggerEnter(Collider other)
    {
        if (!interacted)
        {
            interactButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        interactButton.SetActive(false);
    }

    public void interacting()
    {
        interacted = true;
        useButon.SetActive(true);
        ammoUI.SetActive(true);
        interactButton.SetActive(false); 
        onWall.SetActive(false);
        onPlayer.SetActive(true);
        Destroy(this.gameObject);
    }
}
