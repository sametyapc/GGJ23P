using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpSpeed;
    Rigidbody m_rb;
    Vector3 moveInput;
    Animator m_anim;

    bool canDoubleJump;
    bool onGround;
    [SerializeField] Transform groundChecker;
    [SerializeField] Transform bulletExitPoint;

    [SerializeField] bool isHorizontal; // Duruma göre sadece 2d hareket edebilecek!!!


    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ControlDirection();
        if (moveInput != Vector3.zero)
        {
            m_anim.SetBool("isMoving", true);
        }
        else
        {
            m_anim.SetBool("isMoving", false);
        }
    }

    private void ControlDirection()
    {
        if (moveInput.x<0)
        {
            bulletExitPoint.eulerAngles = new Vector3(0,180,0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x > 0)
        {
            bulletExitPoint.eulerAngles= new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);

        }
    }

    private void FixedUpdate()
    {
        MoveHorizontal();        
        onGround = Physics.CheckSphere(groundChecker.position, .1f,LayerMask.GetMask("Ground"));
    }

    void MoveHorizontal()
    {
        Vector3 forward = transform.forward;
        if (!isHorizontal)
        {
            forward.y = 0;
            forward = forward.normalized;
        }
        else
        {
            forward = new Vector3(0,0,0);
        }
        
        Vector3 right = transform.right;
        right.y = 0;
        right = right.normalized;

        Vector3 horizontalMovement = (forward * moveInput.z + right * moveInput.x) * movementSpeed;
        horizontalMovement.y = m_rb.velocity.y;
        m_rb.velocity =  horizontalMovement;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector3>();
    }

    void OnJump(InputValue value)
    {
        Vector3 jumpForce = new Vector3(0, jumpSpeed,0);


        if (value.isPressed)
        {
            if (onGround)
            {
                canDoubleJump = true;
                m_rb.velocity += jumpForce;
            }
            else if (canDoubleJump)
            {
                m_rb.velocity = new Vector3(m_rb.velocity.x, 0, m_rb.velocity.z); // Düþüþ hýzýný sýfýrlamak için
                m_rb.velocity += jumpForce;
                canDoubleJump = false;
            }
        }        
    }

    public void PlayShootAnimation()
    {
        m_anim.Play("PlayerATTACK");
    }



}
