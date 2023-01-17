using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum AnimState
//{
//    Idle,
//    walk,
//    talk
//}

public class PlayerCtrl : MonoBehaviour
{
    public Transform cameraTransform;

    public CharacterController characterController;

    public float moveSpeed = 10f;
    public float gravity = -20f;
    public float yVelocity = 0;

    bool isMove;

    AnimState m_AnimState = AnimState.Idle;
    public RuntimeAnimatorController[] m_Anim;//0-idle/1-walk/2-talk
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animCtrl(m_AnimState); //애니메이션

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //움직임이 있는지 판별
        Vector2 moveInput = new Vector2(h, v);
        bool isMove = moveInput.magnitude != 0;

        Vector3 moveDirection = new Vector3(h, 0, v);
        moveDirection = cameraTransform.TransformDirection(moveDirection);

        moveDirection *= moveSpeed;

        if (characterController.isGrounded)
        {
            yVelocity = 0;
        }

        yVelocity += (gravity * Time.deltaTime);

        moveDirection.y = yVelocity;

        if (isMove == false)
        {
            m_AnimState = AnimState.Idle;
        }
        else if (isMove == true)
        {
            m_AnimState = AnimState.walk;
            characterController.Move(moveDirection * Time.deltaTime);
        }

    }

    void animCtrl(AnimState AnimType)
    {
        if (AnimType == AnimState.Idle)
        {
            m_Animator.runtimeAnimatorController = m_Anim[0];
        }
        else if (AnimType == AnimState.walk)
        {
            m_Animator.runtimeAnimatorController = m_Anim[1];
        }
        else if (AnimType == AnimState.talk)
        {
            m_Animator.runtimeAnimatorController = m_Anim[2];
        }
    }
}
