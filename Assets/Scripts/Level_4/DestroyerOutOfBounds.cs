using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOutOfBounds : MonoBehaviour
{
    [SerializeField]
    private float topZ;
    [SerializeField]
    private float bottomZ;
    

    void Update()
    {
        if (gameObject.transform.position.z > topZ)
        {
            Destroy(gameObject);
            Debug.Log("Food has gone");
        }
        else if (gameObject.transform.position.z < bottomZ)
        {
            Destroy(gameObject);
            Debug.Log("Cat has gone");
        }
    }
}
