using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragTrigger : MonoBehaviour
{
    [Header("DragTrigger Core")]
    [SerializeField] public bool dragged = false;
    [SerializeField] public bool interacted = false;
    [Header("UI to hide")]
    [SerializeField] private GameObject Joystick;    
    [Header("UI to Show on Trigger Enter")]
    [SerializeField] private GameObject interractButton;
    [Header("UI to Show on Interacting")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject sliderUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dragged)
        {
            interractButton.SetActive(true);
        }
    }

    private void Update()
    {
        if (interacted)
        {
            Joystick.GetComponent<Canvas>().enabled = false;
            interractButton.SetActive(false);
            backButton.SetActive(true);
            sliderUI.SetActive(true);
        }
        if (dragged)
        {
            Joystick.GetComponent<Canvas>().enabled = true;
            backButton.SetActive(false);
            sliderUI.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    public void interact()
    {
        interacted = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interacted = false;
            interractButton.SetActive(false);
        }
    }

    public void backPressed()
    {
        interacted = false;
        Joystick.GetComponent<Canvas>().enabled = true;
        backButton.SetActive(false);
        sliderUI.SetActive(false);
    }

}
