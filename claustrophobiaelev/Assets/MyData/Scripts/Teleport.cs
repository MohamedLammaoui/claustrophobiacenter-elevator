using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   public GameObject player;
   public void TeleportPlayer()
   {
       player.transform.position = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
   }

    public void TeleportPlayerOutside()
    {
        player.transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z + 1.0f);
    }

    public void TeleportPlayerInside()
    {
        player.transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z - 1.3f);
    }
}
