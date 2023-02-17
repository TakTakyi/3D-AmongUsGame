using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjects : MonoBehaviour
{
    // ��� ����Ʈ ��ũ��Ʈ�� ��� ���� ���� ��ũ��Ʈ

    public GameObject m_UseUICanvas;  //Ű���� ���̴� ĵ����
    public bool Quest_Available; //����Ʈ ���డ�� ��������
    public GameObject m_QuestCanvas; //����Ʈ�� �����ϴ� ĵ���� ����

    //����Ʈ �ݱ� ��ư
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
    {   //Ű����� UI OnOff �Լ�
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
    {   //�������� ����Ʈ�� �����ϴ� UI ONOFF�Լ�
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
        //����Ʈ ������ �ݱ� ��ư Ŭ���� �ʱ�ȭ �� ĵ���� ����
        Debug.Log("��ưŬ��");
        OnOffQuestCanvas(false);
    }
}
