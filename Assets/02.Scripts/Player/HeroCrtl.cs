using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum AnimState
{
    Idle,
    walk,
    talk
}

public enum PlayerState
{
    Idle,
    Move,
    Questing,
}

public class HeroCrtl : MonoBehaviour
{
    [Header("----- UI변수 -----")]
    public GameObject m_InfoKey;
    public Text m_InfoKeyText;

    [Header("----- 캐릭터 이동 변수 -----")]
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

    //캐릭터 컨트롤러 변수
    public CharacterController characterController;
    //캐릭터의 이동 체크용 불형 변수
    bool isMove = false;
    //애니메이션 적용 변수
    AnimState m_AnimState = AnimState.Idle;
    public RuntimeAnimatorController[] m_Anim;//0-idle/1-walk/2-talk
    public Animator m_Animator;

    //레이캐스트 테스트
    private RaycastHit m_RayHit;
    private bool m_RayCheckHit;
    private Ray m_Ray;
    private float m_RayDist = 5.0f;
    public LayerMask m_QuestLayer;

    public PlayerState m_PState = PlayerState.Move;

    // Start is called before the first frame update
    void Start()
    {
        //UI
        m_InfoKey.SetActive(false);

        //myRigid = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PState == PlayerState.Move)
        {
            animCtrl(m_AnimState); //애니메이션 적용 함수
            Move();                //캐릭터 이동 함수
            CameraRotation();      //카메라 좌우 움직이기
            CharacterRotation();   //카메라 상하 움직이기
        }

        CameraRayFunc(); //카메라에서 레이 쏴서 쿼스트 및 시체 탐지 및 임포스터 살인 구현함수
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

    void CameraRayFunc()
    {
        //화면 가운데 광선 쏘기
        m_Ray = theCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        m_RayCheckHit = Physics.Raycast(m_Ray, out m_RayHit, m_RayDist, m_QuestLayer);

        if (m_RayCheckHit)
        {
            Debug.DrawRay(m_Ray.origin, theCamera.transform.forward * m_RayDist, Color.green);
            //Debug.DrawLine(m_Ray.origin, m_RayHit.point, Color.green);
            Debug.Log("이름 + " + m_RayHit.transform.name);

            if (m_RayHit.collider.gameObject.GetComponent<QuestObjects>().Quest_Available == true)
            {
                m_RayHit.collider.gameObject.GetComponent<QuestObjects>().OnOffCanvas(true);
                m_InfoKey.SetActive(true);
            }
            else
            {
                m_RayHit.collider.gameObject.GetComponent<QuestObjects>().OnOffCanvas(false);
                m_InfoKey.SetActive(false);
                m_PState = PlayerState.Move;
            }


            if (Input.GetKeyDown(KeyCode.F))
            {
                m_PState = PlayerState.Questing;
                m_RayHit.collider.gameObject.GetComponent<QuestObjects>().OnOffQuestCanvas(true);
            }

            if (m_RayHit.collider.gameObject.GetComponent<QuestObjects>().m_QuestCanvas.activeSelf == false)
            {
                m_PState = PlayerState.Move;
            }
        }
        else
        {
            Debug.DrawRay(m_Ray.origin, theCamera.transform.forward * m_RayDist, Color.red);
            m_InfoKey.SetActive(false);
            //m_RayHit.collider.gameObject.GetComponent<QuestObjects>().OnOffCanvas(false);
        }
    }
}
