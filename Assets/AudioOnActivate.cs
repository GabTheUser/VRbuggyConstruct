using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AudioOnActivate : MonoBehaviour
{
    [SerializeField] private MoveToObjectAndLookAtPlayer moveToObj;
    [SerializeField]
    private Transform target;
    [SerializeField] private GameObject mark2;
    [SerializeField] private VoiceLines voiceLines;
    [SerializeField] private GrabDeactive grabDeactive;
    void OnEnable()
    {
        voiceLines.audioSource.Stop();
        voiceLines.audioSource.clip = voiceLines.voicelines[4];
        voiceLines.audioSource.Play();
        mark2.SetActive(true);
        grabDeactive.enabled = true;
        moveToObj.target = target;
        enabled = false;
    }
}
