using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Animator animator;
    private CharacterController controller;
    [SerializeField] float speed = 1f; //0.025
    float velX, velZ, velY;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float deceleration = 2f;
    [SerializeField] float MaxVel = 1f;
    private Vector3 direction = Vector3.zero;
    private AudioSource walkingSound;

    int velocityXHash;
    int velocityYHash;

    public bool canMove = true;
    public float _gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        velocityXHash = Animator.StringToHash("VelocityX");
        velocityYHash = Animator.StringToHash("VelocityZ"); // Actually Velocity Z
        walkingSound = GetComponent<AudioSource>();

        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void ApplyGravity()
    {
        if (!controller.isGrounded)
        { 
            velY += _gravity * Time.deltaTime;
        }
        else
        {
            velY = 0f;
        }

        //Debug.Log(controller.isGrounded);
    }
    void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, float currentMaxVel, bool backwardPressed)
    {
        if (forwardPressed && velZ < currentMaxVel)
        {
            velZ += Time.deltaTime * acceleration;
        }

        if (leftPressed && velX > -currentMaxVel)
        {
            velX -= Time.deltaTime * acceleration;
        }

        if (rightPressed && velX < currentMaxVel)
        {
            velX += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velZ > 0f)
        {
            velZ -= Time.deltaTime * deceleration;
        }

        if (!backwardPressed && velZ < 0f)
        {
            velZ += Time.deltaTime * deceleration;
        }

        if (backwardPressed && velZ > -currentMaxVel )
        {
            velZ -= Time.deltaTime * acceleration;
        }

        if (!rightPressed && velX > 0f)
        {
            velX -= Time.deltaTime * deceleration;
        }
        if (!leftPressed && velX < 0f)
        {
            velX += Time.deltaTime * deceleration;
        }
    }

    void LockResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, float currentMaxVel, bool backwardPressed)
    {

        if (!forwardPressed && !backwardPressed && (velZ > -0.05f && velZ < 0.05f))
        {
            velZ = 0f;
        }

        if (!rightPressed && !leftPressed && velX != 0f && (velX > -0.05f && velX < 0.05f))
        {
            velX = 0f;
        }

        if (backwardPressed && velZ < -currentMaxVel)
        {
            velZ = -currentMaxVel;
        }

        if (forwardPressed && velZ > currentMaxVel)
        {
            velZ = currentMaxVel;
        }
        else if (forwardPressed && velZ > currentMaxVel)
        {
            velZ -= Time.deltaTime * deceleration;

            if (forwardPressed && velZ > currentMaxVel && velZ < (currentMaxVel + 0.05f))
            {
                velZ = currentMaxVel;
            }
        }
        else if (forwardPressed && velZ < currentMaxVel && velZ > (currentMaxVel - 0.05f))
        {
            velZ = currentMaxVel;
        }
    }

    void Update()
    {
        bool forward = Input.GetKey(KeyCode.W);
        bool right = Input.GetKey(KeyCode.D);
        bool backward = Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.A);

        ChangeVelocity(forward, left, right, MaxVel, backward);
        LockResetVelocity(forward, left, right, MaxVel, backward);
        ApplyGravity();


        Vector3 moveVector = new Vector3(velX, velY, velZ) * speed;
        direction = transform.TransformDirection(moveVector);

        if (canMove)
        {
            controller.Move(direction);
        }
        else
        {
            velX = 0f;
            velZ = 0f;
        }
            animator.SetFloat(velocityXHash, velX);
            animator.SetFloat(velocityYHash, velZ);

        if(velX != 0 ||  velZ != 0)
        {
            walkingSound.enabled = true;
        }
        else
        {
            walkingSound.enabled = false;
        }
    }
}
