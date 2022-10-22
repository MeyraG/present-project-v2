using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemChainController : MonoBehaviour
{
    public int id;
    public List<GameObject> items = new List<GameObject>();
    public bool isTouch;

    //private Vector3 mousePosition;
    private Vector3 offset;
    private Vector3 lastPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            Debug.Log("Triggerin ilk ifi");
            other.gameObject.GetComponent<ItemChainController>().isTouch = true;
            Destroy(gameObject);
            InvokeRepeating("SpawnRandomItems", 1.5f, 1.2f);

            if (isTouch != true)
            {
               
                Instantiate(items[id + 1], transform.position, Quaternion.identity);
                Debug.Log("Triggerin ikinci if satýrý");
            }
        }
    }

    private void OnMouseDown()
    {
        //isTouch = false;

        lastPosition = transform.position;

        offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 73)) - transform.position;
       
        Debug.Log("onMouseDown");
    }

    private void OnMouseDrag()
    {
        //var offsetMousePos = Input.mousePosition + new Vector3(offsetX, offsetY, offsetZ);

        //mousePosition = Camera.main.ScreenToWorldPoint(offsetMousePos);
        //transform.position = mousePosition;
       
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 73));
        Vector3 newPosition = mousePosition - offset;

        //newPosition = new Vector3(newPosition.x, 0, newPosition.z);
        newPosition.y = -5.5f;
        transform.localPosition = newPosition;
        //Debug.Log("onMouseDrag " + mousePosition +   "Offset : " + offset);
    }

    private void OnMouseUp()
    {
        transform.position = lastPosition;
        isTouch = true;
        Debug.Log("onMouseUp");
    }

    void SpawnRandomItems()
    {
        int index = Random.Range(0, 3);
        Instantiate(items[index], lastPosition, Quaternion.identity);
    }

    //void EndLevel()
    //{
    //    if (id == items.Count)
    //    {
    //        GameManager.Instance.
    //    }
    //}
}
