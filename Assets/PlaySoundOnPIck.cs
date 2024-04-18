using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaySoundOnPIck : MonoBehaviour
{
    [SerializeField] private MoveToObjectAndLookAtPlayer moveToObj;
    [SerializeField]
    private Transform target;
    private XRGrabInteractable grabbable;
    [SerializeField] private VoiceLines voiceLines;
    [SerializeField] private GameObject mark1;

    private void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
    }
    public void ImSelected()
    {
        //if (grabbable.isSelected)
        {
            voiceLines.audioSource.Stop();
            voiceLines.audioSource.clip = voiceLines.voicelines[3];
            voiceLines.audioSource.Play();
            mark1.SetActive(false);
            moveToObj.target = target;
            enabled = false;
        }
    }
}
