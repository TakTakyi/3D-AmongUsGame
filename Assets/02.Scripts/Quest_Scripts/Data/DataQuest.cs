using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataQuest : QuestObjects
{ 
    public Button m_DataDownBtn;
    public GameObject m_Progress;

    [Header("------Im-------")]
    //프로그래스 이미지
    public Image m_ProImg;
    public Text m_TimeText;
    public float DownSpeed = 0.01f;

    public Image m_SendUI;
    public Sprite m_SendImg1;
    public Sprite m_SendImg2;

    public Image m_ReciveUI;
    public Sprite m_RecImg1;
    public Sprite m_RecImg2;

    public Image m_ChaImg;
    Vector2 m_ChaImgPos;

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas.SetActive(false);
        Quest_Available = true;

        m_ProImg.fillAmount = 0;
        m_TimeText.text = "Estimated Time : 24h 00m 00s";
        m_ChaImgPos = m_ChaImg.rectTransform.anchoredPosition;
        m_RecImg1 = m_ReciveUI.sprite;
        m_SendImg1 = m_SendUI.sprite;

        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(() =>
            {
                m_QuestCanvas.SetActive(false);
                //초기화 함수로 빼끼
                m_ProImg.fillAmount = 0.0f;
                m_DataDownBtn.gameObject.SetActive(true);
                m_Progress.SetActive(false);
                m_ChaImg.gameObject.SetActive(false);
                m_SendUI.sprite = m_SendImg1;
                m_ReciveUI.sprite = m_RecImg1;
                m_ChaImg.rectTransform.anchoredPosition = m_ChaImgPos;
            });
        }
        //다운로드 버튼 클릭
        if (m_DataDownBtn != null)
        {
            m_DataDownBtn.onClick.AddListener(() =>
            {
                m_Progress.SetActive(true);
                m_DataDownBtn.gameObject.SetActive(false);

                m_SendUI.sprite = m_SendImg2;
                m_ChaImg.gameObject.SetActive(true);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {    
        if (m_Progress.activeSelf == true && m_ProImg.fillAmount <= 1.0f)
        {
            m_ProImg.fillAmount += Time.deltaTime * DownSpeed;
            m_TimeText.text = "다운로드 중";
        }

        if (m_ProImg.fillAmount >= 1.0f)
        {
            m_TimeText.text = "다운로드 완료";
            m_QuestCanvas.SetActive(false);
        }

        if (m_ChaImg.gameObject.activeSelf == true)
        {
            Vector2 a_StartPos = m_ChaImg.rectTransform.anchoredPosition;
            Vector2 a_EndPos = new Vector2(180.0f, a_StartPos.y);

            float moveSpeed = 1.0f;

            m_ChaImg.rectTransform.anchoredPosition = Vector2.Lerp(a_StartPos, a_EndPos, moveSpeed * Time.deltaTime);

            if (m_ChaImg.rectTransform.anchoredPosition.x >= 0.0f)
            {
                m_ReciveUI.sprite = m_RecImg2;
                m_SendUI.sprite = m_SendImg1;
            }

            if (m_ChaImg.rectTransform.anchoredPosition.x >= 160.0f)
            {
                m_ChaImg.gameObject.SetActive(false);
                m_ReciveUI.sprite = m_RecImg1;
            }
        }
        if (m_ChaImg.rectTransform.anchoredPosition.x >= 160.0f && m_ReciveUI.sprite == m_RecImg1)
        {
            m_ChaImg.rectTransform.anchoredPosition = m_ChaImgPos;
            m_SendUI.sprite = m_SendImg2;
            m_ChaImg.gameObject.SetActive(true);
        }
    }

    public override void QuestComp()
    {
        base.QuestComp();
    }

    public override void OnOffCanvas(bool OnOff)
    {
        base.OnOffCanvas(OnOff);
    }

    public override void OnOffQuestCanvas(bool OnOff)
    {
        base.OnOffQuestCanvas(OnOff);
    }

    public override void CloseBtnFunc()
    {
        base.CloseBtnFunc();
    }
}
