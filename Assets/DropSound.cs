using UnityEngine;

public class DropSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.pitch = Random.Range(0.6f, 1.2f);
        audioSource.PlayOneShot(audioSource.clip);
    }
}
