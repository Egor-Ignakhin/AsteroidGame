using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivator : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (var rb in transform.GetComponentsInChildren<Rigidbody>())
        {
           rb.isKinematic = true;
           rb.useGravity = false;
        }

        GetComponent<Animator>().enabled = true;
    }
    private void OnDisable()
    {
        foreach (var rb in transform.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        GetComponent<Animator>().enabled = false;
    }
}
