using UnityEngine;

public class FixRotation : MonoBehaviour
{
    public Quaternion howToFix;
    private void Start()
    {
        howToFix = transform.rotation;
    }
    private void Update()
    {
        transform.rotation = howToFix;
    }
}
