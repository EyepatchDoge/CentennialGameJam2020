using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FungusTrigger : MonoBehaviour
{
    public GameObject Trigger;
    public string player;
    public string messagetoSend;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player))
        {
            Fungus.Flowchart.BroadcastFungusMessage(messagetoSend);
        }
    }

}
   