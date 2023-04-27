using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Empty_Trash : QuestObjects
{
    public GameObject m_BoxCol;   //�ݸ��� isTrigger ���� ����
    public Button m_EmBtn;        //������ ������ ��ư

    public GameObject[] m_TrashOBJ;     //�������θ� �Ǵ��ϱ����� �迭 ����
    private GameObject[] m_TrashPos = new GameObject[20];    //������ ���� ��ġ ����� ����

    //��鸮�� ����� ���� ����
    public GameObject m_TotalPanel;
    private RectTransform m_Rect;
    private bool MStart = false;
    [SerializeField]
    private float m_roughness;      //��ĥ�� ����
    [SerializeField]
    private float m_magnitude;      //������ ����

    // Start is called before the first frame update
    void Start()
    {
        for (int ii = 0; ii < m_TrashOBJ.Length; ii++)
        {
            m_TrashPos[ii].transform.position = m_TrashOBJ[ii].transform.position; //�ʱ���ġ ����
        }

        Quest_Available = true;
        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }

        m_Rect = m_TotalPanel.GetComponent<RectTransform>();
        if (m_EmBtn != null)
        {
            m_EmBtn.onClick.AddListener(() =>
            {
                m_BoxCol.GetComponent<BoxCollider2D>().isTrigger = true;
                //��鸮�� ��� �������� 
                MStart = true;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MStart == true)
        {
            StartCoroutine(Shake(5.0f));
        }

        if (JudgeComp() == true)
        {
            QuestComp();
        }

        for (int ii = 0; ii < m_TrashPos.Length; ii++)
        {
            RectTransform a_Rect = m_TrashPos[ii].GetComponent<RectTransform>();
            Debug.Log(a_Rect.anchoredPosition);
        }
    }

    IEnumerator Shake(float duration) //���� �Լ�
    {
        float halfDuration = duration / 2;
        float elapsed = 0f;
        float tick = 1.0f;//Random.Range(-10f, 10f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime / halfDuration;

            tick += Time.deltaTime * m_roughness;
            m_Rect.anchoredPosition = new Vector3(
                Mathf.PerlinNoise(tick, 0) - .5f,
                Mathf.PerlinNoise(0, tick) - .5f,
                0f) * m_magnitude * Mathf.PingPong(elapsed, halfDuration);

            yield return null;
        }
    }

    public override void QuestComp()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        OnOffQuestCanvas(false);
        OnOffUICanvas(false);
        Quest_Available = false;
    }

    public bool JudgeComp()
    {
        for (int ii = 0; ii < m_TrashOBJ.Length; ii++)
        {
            if (m_TrashOBJ[ii].gameObject.activeSelf != false)
            {
                return false;
            }

        }
        
        return true;
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
        //������ ��ġ �ʱ�ȭ
        for (int ii = 0; ii < m_TrashOBJ.Length; ii++)
        {
            m_TrashOBJ[ii] = m_TrashPos[ii];
        }

        //����Ʈ ������ �ݱ� ��ư Ŭ���� �ʱ�ȭ �� ĵ���� ����
        Debug.Log("��ưŬ��");
        OnOffQuestCanvas(false);
    }
}
