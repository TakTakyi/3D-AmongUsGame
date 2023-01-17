using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AnimState
{
    Idle,
    walk,
    talk
}

public class HeroCrtl : MonoBehaviour
{
    [SerializeField]
    //이동속도
    private float walkSpeed;

    [SerializeField]
    //마우스 감도
    private float lookSensitivity;

    [SerializeField]
    //카메라 제한 각도
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    [SerializeField]
    //카메라 연결용
    private Camera theCamera;

    //private Rigidbody myRigid;
    public CharacterController characterController;

    bool isMove = false;

    AnimState m_AnimState = AnimState.Idle;
    public RuntimeAnimatorController[] m_Anim;//0-idle/1-walk/2-talk
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        //myRigid = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animCtrl(m_AnimState); //애니메이션
        Move();
        CameraRotation();
        CharacterRotation();
    }

    private void Move()
    {
        //플레이어가 움직는 값을 설정하기
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDriZ = Input.GetAxisRaw("Vertical");

        //움직임이 있는지 판별
        Vector2 moveInput = new Vector2(_moveDirX, _moveDriZ);
        isMove = moveInput.magnitude != 0;

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDriZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        //myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        if (isMove == false)
        {
            m_AnimState = AnimState.Idle;
        }
        else if (isMove == true)
        {
            m_AnimState = AnimState.walk;
            characterController.Move(_velocity * Time.deltaTime);
        }
    }

    private void CharacterRotation()
    {
        //캐릭터를 좌우로 움직이기
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        //myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        this.transform.Rotate(_characterRotationY, Space.Self);
    }

    private void CameraRotation()
    {

        //카메라 상하로 움직이기
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    void animCtrl(AnimState AnimType)
    { //애니메이션 적용 함수
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
