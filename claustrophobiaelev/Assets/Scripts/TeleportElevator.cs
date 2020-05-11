using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeleportElevator : MonoBehaviour
{
    public GameObject player;

    public void TeleportPlayerOutside()
    {
        player.transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y , transform.position.z + 1.0f);
    }

    public void TeleportPlayerInside()
    {
        player.transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z - 1.0f);
    }
}
