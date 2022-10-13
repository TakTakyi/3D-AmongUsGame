using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AnimState
{
    Idle,
    walk,
    run,
    Jump,
    talk
}

public class HeroCrtl : MonoBehaviour
{
    public Transform HeroBody;
    public Transform CameraArm;

    AnimState m_AnimState = AnimState.Idle;
    public RuntimeAnimatorController[] m_Anim;//0-idle/1-walk/2-run/3-talk
    public Animator m_Animator;

    bool isRun = false;
    bool isJump = false;
    float m_MoveSpeed = 5.0f;
    float jumptime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animCtrl(m_AnimState);
        LookAround();
        MoveCtrl();
    }

    void LookAround()
    {
        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 CamAngle = CameraArm.rotation.eulerAngles;

        //추가
        float x = CamAngle.x - mousePos.y;
        if (x < 180.0f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        CameraArm.rotation = Quaternion.Euler(x, CamAngle.y + mousePos.x, CamAngle.z);
    }

    void MoveCtrl()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        jumptime -= Time.deltaTime;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)&& jumptime <= 0.0f)
        {
            jumptime = 1.03f;
            isJump = true;
        }
        else if(jumptime<= 0.0f)
        {
            m_Animator.applyRootMotion = false;
            isJump = false;
        }


        if (isMove && isRun == false)
        {
            Move(moveInput, m_MoveSpeed);
            if(isJump == false)
            {
                m_AnimState = AnimState.walk;
            }
            else
            {
                Jump();
            }
        }
        else if (isMove && isRun == true)
        {
            Move(moveInput, m_MoveSpeed * 2);
            if (isJump == false)
            {
                m_AnimState = AnimState.run;
            }
            else
            {
                Jump();
            }
        }
        else
        {
            if (isJump == false)
            {
                m_AnimState = AnimState.Idle;
            }
            else
            {
                Jump();
            }
        }

        //Debug.DrawRay(CameraArm.position, 
        //    new Vector3(CameraArm.forward.x, 0f, CameraArm.forward.z).normalized
        //    , Color.red);
    }
    void Jump()
    {
        m_Animator.applyRootMotion = true;
        m_AnimState = AnimState.Jump;
    }

    void Move(Vector2 moveInput, float a_MoveSpeed)
    {
        Vector3 lookForward = new Vector3(CameraArm.forward.x, 0f, CameraArm.forward.z).normalized;
        Vector3 lookRight = new Vector3(CameraArm.right.x, 0f, CameraArm.right.z).normalized;
        Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

        HeroBody.forward = moveDir;
        transform.position += moveDir * Time.deltaTime * a_MoveSpeed;
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
        else if (AnimType == AnimState.run)
        {
            m_Animator.runtimeAnimatorController = m_Anim[2];
        }
        else if (AnimType == AnimState.Jump)
        {
            m_Animator.runtimeAnimatorController = m_Anim[3];
        }
        else if (AnimType == AnimState.talk)
        {
            m_Animator.runtimeAnimatorController = m_Anim[4];
        }
    }
}
