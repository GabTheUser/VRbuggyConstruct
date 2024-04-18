using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractor : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLength;
    public LayerMask layerMask;
    public LineRenderer lineRenderer;
    public Transform pointo;
    public Color[] colours;

    private MainObject mainObjecto;
    private Material pointoMaterial;
    InputDevice device;
    public ActionBasedController controller; // Reference to the XR Controller
    private bool isInteracting; // Flag to track if we are interacting
    RaycastHit hit;
    Ray myRay;
    private float maxTimeToClick = 0.5f, curTimeToClick;
    private void Start()
    {
        mainObjecto = FindObjectOfType<MainObject>();
        pointoMaterial = pointo.GetComponent<MeshRenderer>().material;
        pointo.gameObject.SetActive(true);

        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if(rightHandDevices.Count > 0 )
        device = rightHandDevices[0];
    }

    private void Update()
    {
        if (curTimeToClick <= 0)
        {
            bool AValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out AValue) && AValue)
            {
                CheckWhatRayDoes();
                curTimeToClick = maxTimeToClick;
            }
            bool BValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out BValue) && BValue)
            {
                SceneManager.LoadScene(0);
                curTimeToClick = maxTimeToClick;
            }
        }
        else
        {
            curTimeToClick -= Time.deltaTime;
        }
            
        
        myRay = new Ray(rayOrigin.position, transform.forward);
        lineRenderer.SetPosition(0, rayOrigin.position);
        lineRenderer.SetPosition(1, transform.forward * rayLength);
        //spointo.gameObject.SetActive(false);
        pointo.position = lineRenderer.GetPosition(1);
    }

    public void CheckWhatRayDoes()
    {
        

        if (Physics.Raycast(myRay.origin, myRay.direction, out hit, rayLength, layerMask))
        {
            //pointo.gameObject.SetActive(true);
            if (hit.collider.CompareTag("Uicall"))
            {
                lineRenderer.startColor = colours[1];
                lineRenderer.endColor = colours[1];
                pointoMaterial.color = colours[1];

                if (hit.collider.GetComponent<ContainUI>())
                {
                    ContainUI containUi = hit.collider.GetComponent<ContainUI>();
                    containUi.uIElements.SetActive(!containUi.uIElements.activeSelf);
                    mainObjecto.currentObj = containUi.myObject;
                    mainObjecto.DisplayUI(containUi.uIElements.activeSelf);
                }
            }

            lineRenderer.SetPosition(0, rayOrigin.position);
            lineRenderer.SetPosition(1, hit.point);
            pointo.position = hit.point;
        }
        else
        {
            lineRenderer.SetPosition(0, rayOrigin.position);
            lineRenderer.SetPosition(1, transform.forward * rayLength);
            //spointo.gameObject.SetActive(false);
            pointo.position = lineRenderer.GetPosition(1);
        }
    }
}
