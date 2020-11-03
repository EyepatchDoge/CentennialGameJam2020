using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject player;
    public Transform SpawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Can 
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player has collided");
            player.transform.position = SpawnPoint.transform.position;
            player.transform.rotation = Quaternion.identity;
        }
    }
}
