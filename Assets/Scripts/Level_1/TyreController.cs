using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyreController : MonoBehaviour
{
    public PlayerController playerCont;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Tyre must be moved");
            playerCont.Damage(10);
            playerCont.healthBar.SetHealth(playerCont.currentHealth);

        }
    }
    void Update()
    {
        //    if (gameObject.tag == "Tyre")
        //    {
        //        Debug.Log("Yes I'm Tyre");

        //        if (this.gameObject.transform.position.y < 0)
        //        {
        //            Debug.Log("Im coming from inside if");
        //            tyreController.enabled = false;
        //        }
        //    }
    }
}