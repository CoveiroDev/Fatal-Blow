using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Status myStatus;

    void Awake()
    {
        myStatus = GetComponentInParent<Status>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Status status = other.GetComponent<Status>();
        if (status != null)
        {
            myStatus.DeactivateDamage();
            status.TakeDamage(myStatus);
        }
    }
}
