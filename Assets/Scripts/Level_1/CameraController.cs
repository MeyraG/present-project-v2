using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = new Vector3(0f, player.position.y, player.position.z) + offset;
    }
}
