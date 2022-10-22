using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkateControl : MonoBehaviour
{
    ScoreController scoreController;
    private Rigidbody rb;

    [SerializeField]
    private float forwardForce;
    [SerializeField]
    private float sidesForce;

    [SerializeField]
    private float xBounds;

    private Vector3 firstPos;
    private Vector3 endPos;

    public Animator playerAnim;


    public float horizontalInput;
    public float jumpForce;
    private bool isGround = true;
    private bool isGameOver = false;

    public Camera mainCam;
    public Camera hoodCam;
    public KeyCode switchKey;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.isGameActive = true;
        scoreController = GetComponent<ScoreController>();
        //playerAnim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);


        //***Movement With Mouse Dragging***
        //if (Input.GetMouseButtonDown(0))
        //{
        //    firstPos = Input.mousePosition;
        //}

        //else if (Input.GetMouseButton(0))
        //{
        //    endPos = Input.mousePosition;
        //    float difference = endPos.x - firstPos.x;
        //    transform.Translate(difference * Time.deltaTime * sidesForce/2, 0, 0);
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    firstPos = Vector3.zero;
        //    endPos = Vector3.zero;
        //}


        // *** Movement With Keyboard ***
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * forwardForce );
        transform.Rotate(Vector3.up * Time.deltaTime * sidesForce * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && isGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
            //playerAnim.SetTrigger("Jump");
        }


        Vector3 position = transform.position;

        if (transform.position.x < -xBounds)
        {
            position.x = -xBounds;
        }
        else if(transform.position.x > xBounds)
        {
            position.x = xBounds;
        }
        transform.position = position;

        if (Input.GetKeyDown(switchKey))
        {
            mainCam.enabled = !mainCam.enabled;
            hoodCam.enabled = !hoodCam.enabled;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.LevelFailed();

        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.LevelCompleted();
        }
        else if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            scoreController.GetCollectible();
        }

        if (collision.transform.CompareTag("Ground"))
        {
            isGround = true;
            //transform.GetComponent<Animator>().SetTrigger("Jump");
        }
    }
}