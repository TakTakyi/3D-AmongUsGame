using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Empty_Trash : QuestObjects
{
    public GameObject m_BoxCol;   //콜리더 isTrigger 접근 변수
    public Button m_EmBtn;        //쓰레기 버리는 버튼

    public Image[] m_TrashOBJ;     //성공여부를 판단하기위해 배열 선언
    private Vector2[] m_TrashPos = new Vector2[20];    //쓰레기 기존 위치 저장용 변수

    //흔들리는 모션을 위한 변수
    public GameObject m_TotalPanel;
    private RectTransform m_Rect;
    private bool MStart = false;
    [SerializeField]
    private float m_roughness;      //거칠기 정도
    [SerializeField]
    private float m_magnitude;      //움직임 범위

    // Start is called before the first frame update
    void Start()
    {
        //쓰레기들의 초기위치 저장
        for (int ii = 0; ii < m_TrashOBJ.Length; ii++)
        {
            m_TrashPos[ii] = m_TrashOBJ[ii].rectTransform.anchoredPosition;
        }

        Quest_Available = true;
        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }

        m_Rect = m_TotalPanel.GetComponent<RectTransform>();
        if (m_EmBtn != null)
        {
            m_EmBtn.onClick.AddListener(() =>
            {
                m_BoxCol.GetComponent<BoxCollider2D>().isTrigger = true;
                //흔들리는 모션 불형으로 
                MStart = true;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MStart == true)
        {
            StartCoroutine(Shake(5.0f));
        }

        if (JudgeComp() == true)
        {
            QuestComp();
        }

        //for (int ii = 0; ii < m_TrashPos.Length; ii++)
        //{
        //    Debug.Log(m_TrashPos[ii].x + " + " + m_TrashPos[ii].y);
        //} 로그 찍기
    }

    IEnumerator Shake(float duration) //흔들기 함수
    {
        float halfDuration = duration / 2;
        float elapsed = 0f;
        float tick = 1.0f;//Random.Range(-10f, 10f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime / halfDuration;

            tick += Time.deltaTime * m_roughness;
            m_Rect.anchoredPosition = new Vector3(
                Mathf.PerlinNoise(tick, 0) - .5f,
                Mathf.PerlinNoise(0, tick) - .5f,
                0f) * m_magnitude * Mathf.PingPong(elapsed, halfDuration);

            yield return null;
        }
    }

    public override void QuestComp()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        OnOffQuestCanvas(false);
        OnOffUICanvas(false);
        Quest_Available = false;
    }

    public bool JudgeComp()
    {
        for (int ii = 0; ii < m_TrashOBJ.Length; ii++)
        {
            if (m_TrashOBJ[ii].gameObject.activeSelf != false)
            {
                return false;
            }

        }
        
        return true;
    }

    public override void OnOffUICanvas(bool OnOff)
    {
        base.OnOffUICanvas(OnOff);
    }

    public override void OnOffQuestCanvas(bool OnOff)
    {
        base.OnOffQuestCanvas(OnOff);
    }

    public override void CloseBtnFunc()
    {
        //쓰레기 위치 초기화
        for (int ii = 0; ii < m_TrashOBJ.Length; ii++)
        {
            m_TrashOBJ[ii].rectTransform.anchoredPosition = m_TrashPos[ii];
        }

        //퀘스트 수행중 닫기 버튼 클릭시 초기화 및 캔버스 끄기
        Debug.Log("버튼클릭");
        OnOffQuestCanvas(false);
    }
}
