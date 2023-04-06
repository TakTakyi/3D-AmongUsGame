using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty_Trash : QuestObjects
{
    // Start is called before the first frame update
    void Start()
    {
        Quest_Available = true;
        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
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
