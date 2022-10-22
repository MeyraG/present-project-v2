using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsController : MonoBehaviour
{
    public float animSpeedFactor;
    public Animator animator;
    private float speed;
    public Vector2 speedRange;

    [HideInInspector]
    public CatScoreController catScoreController;
    void Start()
    {
      speed = Random.Range(speedRange.x, speedRange.y);
      animator.speed = speed * animSpeedFactor;
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Debug.Log("meow got the food!!");
            Destroy(gameObject);
            catScoreController.GetCatScore();
        }
    }
}
