using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float turnSpeed;
    public float speed;

    private float verticalInput;
    private float horizontalInput;
    public float xAxis;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthSystem healthBar;

    private void Start()
    {
        GameManager.Instance.isGameActive = true;
        currentHealth = maxHealth;
    }


    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Debug.Log("damage çalışıyo");
            GameManager.Instance.LevelFailed();
        }
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(transform.forward * speed * Time.deltaTime);
        //transform.Translate(new Vector3(1, 0, 0) * turnSpeed * horizontalInput);
        //transform.TransformDirection((-transform.forward)* speed*Time.deltaTime);

        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);


        Vector3 position = transform.position;

        if (transform.position.x > xAxis)
        {
            position.x = xAxis;
        }
        else if (transform.position.x < -xAxis)
        {
            position.x = -xAxis;
        }

        transform.position = position;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Damage(10);
            Debug.Log(" Canım " + currentHealth);
            healthBar.SetHealth(currentHealth);
        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.LevelCompleted();
        }
    }
}