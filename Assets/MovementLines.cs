using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementLines : MonoBehaviour
{
    [SerializeField] private MoveToObjectAndLookAtPlayer moveToObj;
    [SerializeField] private Transform target;
    [SerializeField] private Transform characterTransforms;
    private bool turned;
    [SerializeField] private GameObject mark1;
    [SerializeField] VoiceLines voiceLines;

    InputDevice rightController;
    InputDevice leftController;

    private void Start()
    {
        // Find the left and right XR controllers in the XR Rig
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count > 0)
            rightController = rightHandDevices[0];
        var lefHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, lefHandDevices);
        if (lefHandDevices.Count > 0)
            leftController = lefHandDevices[0];
    }

    private void Update()
    {
        if (!turned)
        {
            Vector2 AValue;
            if (rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out AValue) && AValue != Vector2.zero)
            {
                voiceLines.audioSource.Stop();
                voiceLines.audioSource.clip = voiceLines.voicelines[1];
                voiceLines.audioSource.Play();
                turned = true;
            }

        }
        else
        {
            Vector2 BValue;
            if (leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out BValue) && BValue != Vector2.zero)
            {
                voiceLines.audioSource.Stop();
                voiceLines.audioSource.clip = voiceLines.voicelines[2];
                voiceLines.audioSource.Play();
                mark1.SetActive(true);
                moveToObj.target = target;
                enabled = false;
            }
        }

    }
    
}
