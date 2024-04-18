using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WhatToOn : MonoBehaviour
{
    public GameObject myCollisionPoint;
    public GameObject whatToTurnOn;
    private XRGrabInteractable grabbable;
    public MeshRenderer myColMesh;
    private bool placed;
    private MainObject mainObjectScr;
    private void Start()
    {
        mainObjectScr = FindObjectOfType<MainObject>();
        myColMesh = myCollisionPoint.GetComponentInChildren<MeshRenderer>();
        grabbable = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        if (!placed)
        {
            if (grabbable.isSelected)
            {
                myCollisionPoint.SetActive(true);
            }
            else
            {
                myCollisionPoint.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColPoint"))
        {
            if (other.transform.IsChildOf(myCollisionPoint.transform))
            {
                mainObjectScr.currentObj = whatToTurnOn;
                mainObjectScr.MakeTransparent(); //прозрачный эффект при присоединении
                placed = true;
                whatToTurnOn.SetActive(true);
                myColMesh.enabled = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if(myCollisionPoint != null)
        myCollisionPoint.SetActive(true);
        if (myCollisionPoint.GetComponentInChildren<ContainUI>())
        {
            ContainUI containUi = myCollisionPoint.GetComponentInChildren<ContainUI>();
            containUi.gameObject.tag = "Uicall";
            containUi.myObject = whatToTurnOn;
            Destroy(gameObject);
        }
    }
}
