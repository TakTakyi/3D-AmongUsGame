using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Quest : QuestObjects
{
    public GameObject[] m_Shield;
    public MeshRenderer[] m_ShieldRender;
    Color m_Color = new Color(0.0f, 191.0f, 191.0f);

    //public GameObject m_Canvas;

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas.SetActive(false);
        for (int ii = 0; ii < m_Shield.Length; ii++)
        {
            m_ShieldRender[ii] = m_Shield[ii].GetComponent<MeshRenderer>();
        }
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
            Debug.Log("���� ����");
        }
    }

    public override void OnOffCanvas(bool OnOff)
    {
        base.OnOffCanvas(OnOff);
    }


}
