using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScrew : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tool"))
        {
            animator.SetBool("pressed", true);
            gameObject.SetActive(false);
        }
    }
}
