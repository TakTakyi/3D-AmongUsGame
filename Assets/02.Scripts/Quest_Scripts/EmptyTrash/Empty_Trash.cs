using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Empty_Trash : QuestObjects
{
    public GameObject m_BoxCol;   //콜리더 isTrigger 접근 변수
    public Button m_EmBtn;        //쓰레기 버리는 버튼

    public GameObject[] m_TrashOBJ;     //성공여부를 판단하기위해 배열 선언

    // Start is called before the first frame update
    void Start()
    {
        Quest_Available = true;
        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }

        if (m_EmBtn != null)
        {
            m_EmBtn.onClick.AddListener(() =>
            {
                m_BoxCol.GetComponent<BoxCollider2D>().isTrigger = true;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public override void QuestComp()
    {
        base.QuestComp();
    }
}
