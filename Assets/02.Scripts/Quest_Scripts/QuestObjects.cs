using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
    public GameObject m_Canvas;
    //public bool OnOffCV = false;

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
