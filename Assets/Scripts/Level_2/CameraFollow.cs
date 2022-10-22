using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
 
    void LateUpdate()
    {
        transform.position = new Vector3(0f, player.position.y, player.position.z) + offset;
    }
}
