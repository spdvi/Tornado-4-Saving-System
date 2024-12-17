using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapon : MonoBehaviour
{
    public Transform playerHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.parent = playerHand.transform;
            playerHand.gameObject.GetComponent<WeaponManagerPlayer>().AddWeapon(transform);
        }
    }
}
