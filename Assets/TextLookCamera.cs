using UnityEngine;

public class TextLookCamera : MonoBehaviour
{
    public Camera mainCam;
    private void Update()
    {
        transform.LookAt(mainCam.transform.position);
    }
}
