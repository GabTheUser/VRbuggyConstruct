using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WarnUserIfNeed : MonoBehaviour
{
    WhatToOn whatToOn;
    private XRGrabInteractable grabbable;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    private void Start()
    {
        whatToOn = GetComponent<WhatToOn>();
        grabbable = GetComponent<XRGrabInteractable>();
    }
    public void ImSelected()
    {
        //if (grabbable.isSelected)
        {
            if (!whatToOn.myCollisionPoint.transform.parent.gameObject.activeInHierarchy)
            {
                audioSource.Stop();
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}
