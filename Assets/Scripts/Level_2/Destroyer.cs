using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public Transform player;
    void Update()
    {
        if (player.position.z > gameObject.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
