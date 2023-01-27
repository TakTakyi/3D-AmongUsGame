using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
    // 모든 퀘스트 스크립트가 상속 받을 상위 스크립트

    public GameObject m_Canvas;
    public bool Quest_Available;

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void QuestComp()
    {

    }

    public virtual void OnOffCanvas(bool OnOff)
    {   //키설명용 UI OnOff 함수
        if (OnOff == true)
        {
            m_Canvas.SetActive(true);
        }
        else
        {
            m_Canvas.SetActive(false);
        }
    }

    public virtual void OnOffQuestCanvas()
    {   //실직적인 퀘스트를 수행하는 UI

    }
}
