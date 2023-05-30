using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countTextL;
    public TextMeshProUGUI countTextR;
    public TextMeshProUGUI countdownTextL;
    public TextMeshProUGUI countdownTextR;
    public TextMeshProUGUI timerTextL;
    public TextMeshProUGUI timerTextR;
    public GameObject wintextObjectL;
    public GameObject wintextObjectR;
    public GameObject FPCamera;
    public GameObject TPCamera;

    private int count;
    private int move;
    private int change;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float timer;
    private float countdown;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 0;
        move = 0;
        change = 0;
        countdown = 5.0f;
        SetCountText();
        wintextObjectL.SetActive(false);
        wintextObjectR.SetActive(false);
        timerTextL.enabled = false;
        timerTextR.enabled = false;

        TPCamera.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void Update()
    {
        countdownTextL.text = string.Format("{0:00.00}", countdown);
        countdownTextR.text = string.Format("{0:00.00}", countdown);

        countdown -= Time.deltaTime;
        
        if (countdown < 0)
        {
            countdownTextL.enabled = false;
            countdownTextR.enabled = false;
            move = 1;
            timer += Time.deltaTime;
        }
    }

    void SetCountText()
    {
        countTextL.text = "Count: " + count.ToString();
        countTextR.text = "Count: " + count.ToString();
           
        if (count >= 12)
        {
            wintextObjectL.SetActive(true);
            wintextObjectR.SetActive(true);
            timerTextL.enabled = true;
            timerTextR.enabled = true;
            timerTextL.text = string.Format("{0:00.00}",timer);
            timerTextR.text = string.Format("{0:00.00}", timer);
            countTextL.text = "Change: " + change.ToString();
            countTextR.text = "Change: " + change.ToString();

        }
    }
    private void FixedUpdate()
    {
        if (move == 1)
        {
            Vector3 movement = new Vector3(-movementX, 0.0f, -movementY);

            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
                FPCamera.SetActive(true);
                TPCamera.SetActive(false);
            SetCountText();
        }
        if (other.gameObject.CompareTag("wall"))
        {
                FPCamera.SetActive(false);
                TPCamera.SetActive(true);
            change = change + 1;
         
        }

    }
}
