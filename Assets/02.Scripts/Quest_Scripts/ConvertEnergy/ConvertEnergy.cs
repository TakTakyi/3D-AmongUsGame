using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertEnergy : QuestObjects
{
    public Button m_ConEnBtn;
    bool IsStart = false; //회전 스타트 불형

    public Image m_BackImg;
    public Sprite m_BackSprite;

    float Timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_UseUICanvas.SetActive(false);
        Quest_Available = true;

        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }

        if (m_ConEnBtn != null)
        {
            m_ConEnBtn.onClick.AddListener(() =>
            {
                IsStart = true;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStart == true)
        {
            float rotSpeed = 10.0f;
            
            Vector3 q = Vector3.Lerp(m_ConEnBtn.transform.eulerAngles, new Vector3(0, 0, 90), Time.deltaTime * rotSpeed);
            m_ConEnBtn.transform.eulerAngles = q;

            if (m_ConEnBtn.transform.eulerAngles.z >= 89.0f)
            {
                m_ConEnBtn.gameObject.SetActive(false);
                m_BackImg.sprite = m_BackSprite;
            }

            if (m_BackImg.sprite == m_BackSprite)
            {
                Timer -= Time.deltaTime;
                Debug.Log(Timer);
                if (Timer <= 0.0f)
                {
                    QuestComp();
                }
            }
        }

    }

    public override void QuestComp()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        OnOffQuestCanvas(false);
        OnOffUICanvas(false);
        Quest_Available = false;
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
}
