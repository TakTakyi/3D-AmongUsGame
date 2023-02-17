using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjects : MonoBehaviour
{
    // 모든 퀘스트 스크립트가 상속 받을 상위 스크립트

    public GameObject m_UseUICanvas;  //키설명 보이는 캔버스
    public bool Quest_Available; //퀘스트 수행가능 불형변수
    public GameObject m_QuestCanvas; //퀘스트를 수행하는 캔버스 변수

    //퀘스트 닫기 버튼
    public Button m_ClostBtn;

    // Start is called before the first frame update
    void Start()
    {
        m_UseUICanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void QuestComp()
    {

    }

    public virtual void OnOffUICanvas(bool OnOff)
    {   //키설명용 UI OnOff 함수
        if (OnOff == true)
        {
            m_UseUICanvas.SetActive(true);
        }
        else
        {
            m_UseUICanvas.SetActive(false);
        }
    }

    public virtual void OnOffQuestCanvas(bool OnOff)
    {   //실직적인 퀘스트를 수행하는 UI ONOFF함수
        if (OnOff == true)
        {
            m_QuestCanvas.SetActive(true);
        }
        else
        {
            m_QuestCanvas.SetActive(false);
        }
    }

    public virtual void CloseBtnFunc()
    {
        //퀘스트 수행중 닫기 버튼 클릭시 초기화 및 캔버스 끄기
        Debug.Log("버튼클릭");
        OnOffQuestCanvas(false);
    }
}
