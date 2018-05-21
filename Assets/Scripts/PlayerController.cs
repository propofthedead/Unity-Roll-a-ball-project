﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody rb;
    private int count;

        private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        WinText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count=count +1;
            setCountText();
        }
    }
    void setCountText()
    {
        CountText.text="Count: " + count.ToString();
        if(count>=12)
        {
            WinText.text = "You win";
        }
    }
}
