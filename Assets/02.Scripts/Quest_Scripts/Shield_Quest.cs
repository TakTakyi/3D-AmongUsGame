using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield_Quest : QuestObjects
{
    public GameObject[] m_Shield;
    public MeshRenderer[] m_ShieldRender;
    Color m_Color = new Color(0.0f, 191.0f, 191.0f);

    //퀘스트 수행하기 위한 UI 변수
    public GameObject m_ShQuest;
    public Button[] m_Btn;

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas.SetActive(false);
        for (int ii = 0; ii < m_Shield.Length; ii++)
        {
            m_ShieldRender[ii] = m_Shield[ii].GetComponent<MeshRenderer>();
        }

        ShieldQuest();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void QuestComp()
    {
        for (int ii = 0; ii < m_ShieldRender.Length; ii++)
        {
            m_ShieldRender[ii].material.SetColor("_EmissionColor", m_Color * 0.1f);
            gameObject.GetComponent<Outline>().enabled = false;
            Debug.Log("변경 성공");
        }

        m_ShQuest.SetActive(false);
        
    }

    public override void OnOffCanvas(bool OnOff)
    {
        base.OnOffCanvas(OnOff);
    }

    public override void OnOffQuestCanvas()
    {
        m_ShQuest.SetActive(true);

        for (int ii = 0; ii < m_Btn.Length; ii++)
        {
            if (m_Btn[ii].image.color == Color.white)
            {
                QuestComp();
            }
        }
    }

    void ShieldQuest()
    {
        if (m_Btn[0] != null)
        {
            m_Btn[0].onClick.AddListener(() =>
            {
                m_Btn[0].image.color = Color.white;
            });
        }

        if (m_Btn[1] != null)
        {
            m_Btn[1].onClick.AddListener(() =>
            {
                m_Btn[1].image.color = Color.white;
            });
        }

        if (m_Btn[2] != null)
        {
            m_Btn[2].onClick.AddListener(() =>
            {
                m_Btn[2].image.color = Color.white;
            });
        }

        if (m_Btn[3] != null)
        {
            m_Btn[3].onClick.AddListener(() =>
            {
                m_Btn[3].image.color = Color.white;
            });
        }

        if (m_Btn[4] != null)
        {
            m_Btn[4].onClick.AddListener(() =>
            {
                m_Btn[4].image.color = Color.white;
            });
        }

        if (m_Btn[5] != null)
        {
            m_Btn[5].onClick.AddListener(() =>
            {
                m_Btn[5].image.color = Color.white;
            });
        }

        if (m_Btn[6] != null)
        {
            m_Btn[6].onClick.AddListener(() =>
            {
                m_Btn[6].image.color = Color.white;
            });
        }

        if (m_Btn[7] != null)
        {
            m_Btn[7].onClick.AddListener(() =>
            {
                m_Btn[7].image.color = Color.white;
            });
        }

        if (m_Btn[8] != null)
        {
            m_Btn[8].onClick.AddListener(() =>
            {
                m_Btn[8].image.color = Color.white;
            });
        }
    }
}
