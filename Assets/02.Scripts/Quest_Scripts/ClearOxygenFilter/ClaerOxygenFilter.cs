using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaerOxygenFilter : QuestObjects
{
    public SlotScript[] m_SlotSc; //나무잎배열
    public Image a_MsObj = null; //마우스 클릭시 마우스를 따라 다닐 이미지 변수

    int m_SaveIndex = -1;   //클릭한 인덱스 저장
    bool m_IsPick = false;  //클릭여부

    // Start is called before the first frame update
    void Start()
    {
        m_UseUICanvas.SetActive(false);
        Quest_Available = true;

        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼을 클릭한 순간
        {
            MouseBtnDown();
        }//if (Input.GetMouseButtonDown(0))

        if (Input.GetMouseButton(0)) //왼쪽 마우스를 누르고 있는 동안
        {
            if (m_IsPick == true)
            {
                a_MsObj.transform.position = Input.mousePosition;
            }
        }//if (Input.GetMouseButton(0)) 

        if (Input.GetMouseButtonUp(0)) //왼쪽 마우스를 누르고 있다가 뗀 순간
        {
            MouseBtnUp();
        }//if (Input.GetMouseButtonUp(0)) 

        if (JudgeComp() == true)
        {
            QuestComp();
        }
        
    }

    public override void QuestComp()
    {
        gameObject.GetComponent<Outline>().enabled = false;
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

    public override void CloseBtnFunc()
    {
        base.CloseBtnFunc();
    }

    public bool JudgeComp()
    {
        for (int ii = 0; ii < m_SlotSc.Length; ii++)
        {
            if (m_SlotSc[ii].gameObject.activeSelf != false)
            {
                return false;
            }
            
        }
        if (a_MsObj.gameObject.activeSelf == true)
        {
            return false;
        }
        return true;
    }

    bool IsCollSlot(GameObject a_CkObj)  //마우스가 UI 슬롯 오브젝트 위에 있느냐? 판단하는 함수
    {
        Vector3[] v = new Vector3[4];
        a_CkObj.GetComponent<RectTransform>().GetWorldCorners(v);
        if (v[0].x <= Input.mousePosition.x && Input.mousePosition.x <= v[2].x &&
           v[0].y <= Input.mousePosition.y && Input.mousePosition.y <= v[2].y)
        {
            return true;
        }

        return false;
    }

    void MouseBtnDown()
    {
        m_SaveIndex = -1;

        for (int ii = 0; ii < m_SlotSc.Length; ii++)
        {
            if (m_SlotSc[ii].ItemImg.gameObject.activeSelf == true &&
               IsCollSlot(m_SlotSc[ii].gameObject) == true)
            {
                m_SaveIndex = ii;
                m_SlotSc[ii].ItemImg.gameObject.SetActive(false);
                m_IsPick = true;
                a_MsObj.sprite = m_SlotSc[ii].ItemImg.sprite;
                a_MsObj.gameObject.SetActive(true);
                a_MsObj.transform.position = Input.mousePosition;
                break;
            }
        }//for(int ii = 0; ii < m_SlotSc.Length; ii++)
    }//void MouseBtnDown()

    void MouseBtnUp()
    {
        if (m_IsPick == false)
            return;

        for (int ii = 0; ii < m_SlotSc.Length; ii++)
        {
            if (m_SlotSc[ii].ItemImg.gameObject.activeSelf == false &&
                IsCollSlot(m_SlotSc[ii].gameObject) == true)
            {
                m_SlotSc[ii].ItemImg.gameObject.SetActive(true);
                m_SlotSc[ii].ItemImg.color = Color.white;

                m_IsPick = false;
                a_MsObj.gameObject.SetActive(false);
                break;
            }
        }//for(int ii = 0; ii < m_SlotSc.Length; ii++)

        if (m_IsPick == true && 0 <= m_SaveIndex)
        {
            m_SlotSc[m_SaveIndex].ItemImg.transform.position = Input.mousePosition;
            m_SlotSc[m_SaveIndex].ItemImg.gameObject.SetActive(true);
            m_IsPick = false;
            a_MsObj.gameObject.SetActive(false);
        }

    }// void MouseBtnUp()
}
