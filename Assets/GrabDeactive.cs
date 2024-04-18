using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabDeactive : MonoBehaviour
{
    private XRGrabInteractable grabbable;
    [SerializeField] private GameObject mark2;
    private void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
    }
    public void ImSelected()
    {
        mark2.SetActive(false);
        enabled = false;
    }
}
