using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2 : MonoBehaviour
{


    public InputDetector inputDetect;
    public PlayerController controller;
    public float horizontal = 0;
    public float vertical = 0;

    // Use this for initialization
    void Start()
    {
        inputDetect = GetComponent<InputDetector>();
        controller = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        controller.DetectInputDirection();

        // Goes in Horizontal Direction -- Not going up or down  --- Going forward with 5 units of power.
        GetComponent<Rigidbody>().velocity = new Vector3(horizontal, vertical, 5);

        if (controller.direction == InputDirection.Right)
        {

            horizontal = 5;

            StartCoroutine(stopSlide());
        }
        else if (controller.direction == InputDirection.Left)
        {

            horizontal = -5;

            StartCoroutine(stopSlide());
        }
        else if (controller.direction == InputDirection.Up)
        {
            vertical = 5;
            StartCoroutine(stopSlide());
            StartCoroutine(stopJump());
        }


    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.2f);
        horizontal = 0;
        vertical = 0;

        // Resets Direction -- Not needed if you want to constantly go left or right
        controller.direction = InputDirection.None;
    }
    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(.25f);
        vertical = -5;
        StartCoroutine(stopSlide());
        controller.direction = InputDirection.None;
    }
}