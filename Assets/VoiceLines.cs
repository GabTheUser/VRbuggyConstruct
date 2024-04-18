using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VoiceLines : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] voicelines;
    public int currentVoiceLineIdx;
    private void Update()
    {
        switch (currentVoiceLineIdx)
        {
            case 0:
                break;
        }
    }
}
