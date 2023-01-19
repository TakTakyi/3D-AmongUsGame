using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Quest : MonoBehaviour
{
    public GameObject[] m_Shield;
    public MeshRenderer[] m_ShieldRender;
    Color m_Color = new Color(0.0f, 191.0f, 191.0f);

    // Start is called before the first frame update
    void Start()
    {
        for (int ii = 0; ii < m_Shield.Length; ii++)
        {
            m_ShieldRender[ii] = m_Shield[ii].GetComponent<MeshRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int ii = 0; ii < m_ShieldRender.Length; ii++)
            {
                m_ShieldRender[ii].material.SetColor("_EmissionColor", m_Color * 0.1f);
                Debug.Log("변경 성공");
            }

        }
    }
}
