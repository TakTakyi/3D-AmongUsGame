using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairWiring : QuestObjects
{
    public GameObject m_ShQuest;

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas.SetActive(false);
        Quest_Available = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void QuestComp()
    {
        m_ShQuest.SetActive(false);
        OnOffCanvas(false);
        Quest_Available = false;
    }

    public override void OnOffCanvas(bool OnOff)
    {
        base.OnOffCanvas(OnOff);
    }

    public override void OnOffQuestCanvas()
    {
        m_ShQuest.SetActive(true);
    }
}
