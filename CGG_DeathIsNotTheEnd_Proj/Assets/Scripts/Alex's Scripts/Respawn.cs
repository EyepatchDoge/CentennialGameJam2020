using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            player.transform.position = this.GetComponentInChildren<CheckPoints>().lastCheckpoint;
            Physics.SyncTransforms();
        }
    }
}
