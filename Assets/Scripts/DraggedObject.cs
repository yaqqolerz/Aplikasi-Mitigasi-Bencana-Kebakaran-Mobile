using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggedObject : MonoBehaviour
{
    [Header("Object to Drag Core")]
    [SerializeField] private GameObject draggedObj;
    [SerializeField] private DragTrigger trigger;
    [SerializeField] private Slider slider;
    [SerializeField] private bool doneMoving;
    [SerializeField] private bool startMoving;
    [SerializeField] private float speed = 5f;
    [Header("Dragged Object Positions")]
    [SerializeField] private GameObject draggedObjFinishedPos;
    [SerializeField] private Vector3 draggedObjPos;

    private void Update()
    {
        beginMove();
        if (!doneMoving && startMoving)
        {
            if (startMoving)
            {
                moveObj();
            }
        }
    }

    private void moveObj()
    {
        if (trigger != null && !doneMoving)
        {
            draggedObjPos = draggedObj.transform.position;
            if (draggedObj != null)
            {
                draggedObj.transform.position = Vector3.MoveTowards(draggedObj.transform.position, draggedObjFinishedPos.transform.position, speed * Time.deltaTime);

                if (Vector3.Distance(draggedObjPos, draggedObjFinishedPos.transform.position) < 0.001f)
                {
                    doneMoving = true;
                    trigger.dragged = true;
                    trigger.interacted = false;
                }
            }
        }
    }

    private void beginMove()
    {
        if (slider != null)
        {
            if (slider.value >= 1f)
            {
                startMoving = true;
            }
        }  
    }
}
