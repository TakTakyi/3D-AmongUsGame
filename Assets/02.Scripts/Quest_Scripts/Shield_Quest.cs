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
    public Button[] m_Btn;

    // Start is called before the first frame update
    void Start()
    {
        m_UseUICanvas.SetActive(false);
        RandomColor();
        for (int ii = 0; ii < m_Shield.Length; ii++)
        {
            m_ShieldRender[ii] = m_Shield[ii].GetComponent<MeshRenderer>();
        }

        ShieldQuest();
        Quest_Available = true;

        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Quest_Available);

        if (m_QuestCanvas.activeSelf == true)
        {
            if (JudgeComp() == true)
            {
                QuestComp();
            }
        }
    }

    //판정 함수 
    public bool JudgeComp()
    {
        for (int ii = 0; ii < m_Btn.Length; ii++)
        {
            if (m_Btn[ii].image.color != Color.white)
            {
                return false;
            }
            else
                continue;
        }
        return true;
    }

    public override void QuestComp()
    {
        for (int ii = 0; ii < m_ShieldRender.Length; ii++)
        {
            m_ShieldRender[ii].material.SetColor("_EmissionColor", m_Color * 0.1f);
            gameObject.GetComponent<Outline>().enabled = false;
            gameObject.GetComponentInChildren<Monitor>().on = true;
            Debug.Log("변경 성공");
        }

        OnOffQuestCanvas(false);
        OnOffUICanvas(false);
        Quest_Available = false;
    }

    public override void OnOffUICanvas(bool OnOff)
    {
        base.OnOffUICanvas(OnOff);
    }

    public override void OnOffQuestCanvas(bool OnOff)
    {
        base.OnOffQuestCanvas(OnOff);
    }

    void ShieldQuest()
    {
        if (m_Btn[0] != null)
        {
            m_Btn[0].onClick.AddListener(() =>
            {
                if (m_Btn[0].image.color == Color.white)
                {
                    m_Btn[0].image.color = Color.red;
                }
                else if (m_Btn[0].image.color == Color.red)
                {
                    m_Btn[0].image.color = Color.white;
                }
            });
        }

        if (m_Btn[1] != null)
        {
            m_Btn[1].onClick.AddListener(() =>
            {
                if (m_Btn[1].image.color == Color.white)
                {
                    m_Btn[1].image.color = Color.red;
                }
                else if (m_Btn[1].image.color == Color.red)
                {
                    m_Btn[1].image.color = Color.white;
                }
            });
        }

        if (m_Btn[2] != null)
        {
            m_Btn[2].onClick.AddListener(() =>
            {
                if (m_Btn[2].image.color == Color.white)
                {
                    m_Btn[2].image.color = Color.red;
                }
                else if (m_Btn[2].image.color == Color.red)
                {
                    m_Btn[2].image.color = Color.white;
                }
            });
        }

        if (m_Btn[3] != null)
        {
            m_Btn[3].onClick.AddListener(() =>
            {
                if (m_Btn[3].image.color == Color.white)
                {
                    m_Btn[3].image.color = Color.red;
                }
                else if (m_Btn[3].image.color == Color.red)
                {
                    m_Btn[3].image.color = Color.white;
                }
            });
        }

        if (m_Btn[4] != null)
        {
            m_Btn[4].onClick.AddListener(() =>
            {
                if (m_Btn[4].image.color == Color.white)
                {
                    m_Btn[4].image.color = Color.red;
                }
                else if (m_Btn[4].image.color == Color.red)
                {
                    m_Btn[4].image.color = Color.white;
                }
            });
        }

        if (m_Btn[5] != null)
        {
            m_Btn[5].onClick.AddListener(() =>
            {
                if (m_Btn[5].image.color == Color.white)
                {
                    m_Btn[5].image.color = Color.red;
                }
                else if (m_Btn[5].image.color == Color.red)
                {
                    m_Btn[5].image.color = Color.white;
                }
            });
        }

        if (m_Btn[6] != null)
        {
            m_Btn[6].onClick.AddListener(() =>
            {
                if (m_Btn[6].image.color == Color.white)
                {
                    m_Btn[6].image.color = Color.red;
                }
                else if (m_Btn[6].image.color == Color.red)
                {
                    m_Btn[6].image.color = Color.white;
                }
            });
        }

        if (m_Btn[7] != null)
        {
            m_Btn[7].onClick.AddListener(() =>
            {
                if (m_Btn[7].image.color == Color.white)
                {
                    m_Btn[7].image.color = Color.red;
                }
                else if (m_Btn[7].image.color == Color.red)
                {
                    m_Btn[7].image.color = Color.white;
                }
            });
        }

        if (m_Btn[8] != null)
        {
            m_Btn[8].onClick.AddListener(() =>
            {
                if (m_Btn[8].image.color == Color.white)
                {
                    m_Btn[8].image.color = Color.red;
                }
                else if (m_Btn[8].image.color == Color.red)
                {
                    m_Btn[8].image.color = Color.white;
                }
            });
        }
    }

    //랜덤하게 색 컨트롤
    void RandomColor()
    {
        //int idx = Random.Range(0, 2);
        //m_Btn[idx].image.color = Color.red;

        for (int ii = 0; ii < m_Btn.Length; ii++)
        {
            int idx = Random.Range(0, 2);
            if (idx == 1)
            {
                m_Btn[ii].image.color = Color.red;
            }
        }
    }

    public override void CloseBtnFunc()
    {
        base.CloseBtnFunc();
    }
}
