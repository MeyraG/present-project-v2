using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private Rigidbody rigidBody;

    private float minForce = 14;
    private float maxForce = 17;
    private float torque = 7;
    private float xRange = 4;
    private float ySpawnPos = -2;

    private ObjectManager objectManager;

    public ParticleSystem explosion;

    void Start()
    {

        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();

        rigidBody = GetComponent<Rigidbody>();

        rigidBody.AddForce(RandomForce(), ForceMode.Impulse);
        Debug.Log($"vel {rigidBody.velocity}");
        rigidBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isGameActive)
        {
            Destroy(gameObject);
            
            Instantiate(explosion, transform.position, explosion.transform.rotation);

            if (gameObject.CompareTag("Bonus"))
                objectManager.ScoreUpdate(5);

            else if (gameObject.CompareTag("Good"))
            {
                objectManager.ScoreUpdate(2);
            }

            else if(gameObject.CompareTag("Bad"))
            {
                Debug.LogWarning("You fail :( ");
                GameManager.Instance.LevelFailed();
            }

            if (objectManager.score >= 30)
            {
                objectManager.scoreText.text = "SCORE: " +  30.ToString();
                Debug.Log("You WIN!");
                GameManager.Instance.LevelCompleted();               
            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            GameManager.Instance.LevelFailed();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
}
