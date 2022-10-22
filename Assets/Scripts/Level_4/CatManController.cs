using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManController : MonoBehaviour
{
    [SerializeField] 
    private float dragSensitivity;
    [SerializeField]
    private float speed;

    private Rigidbody rb;
    private float refDragSpeed;
    private float smoothX;
    private float targetX;

    private Vector3 mousePrevPos;
    public float moveRange;

    public GameObject[] projectilePrefabs;
    //public float smoothTime = 0.1f;

    private void MoveSides()
    {
        targetX += GetDrag(Vector3.right, dragSensitivity);

        //Ekran sinirlamasi icin benim if'le yaptigim islemin kisasi
        targetX = Mathf.Clamp(targetX, -moveRange , moveRange );

        //smoothX = Mathf.SmoothDamp(smoothX, targetX, ref refDragSpeed, smoothTime);
        smoothX =  Mathf.MoveTowards(smoothX, targetX, speed * Time.deltaTime);

        transform.position = new Vector3(smoothX, transform.position.y, transform.position.z);
    }

    private float GetDrag(Vector3 axis, float sensitivity)
    {
        float drag = Vector3.Dot(axis, Input.mousePosition - mousePrevPos) * sensitivity / Screen.width;

        mousePrevPos = Input.mousePosition;

        return drag;
    }

    private void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            mousePrevPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            MoveSides();
        }

        if (Input.GetMouseButtonDown(1))
        {
            int index = Random.Range(0, projectilePrefabs.Length);
            Instantiate(projectilePrefabs[index], transform.position, projectilePrefabs[index].transform.rotation);
        }
    }
}
