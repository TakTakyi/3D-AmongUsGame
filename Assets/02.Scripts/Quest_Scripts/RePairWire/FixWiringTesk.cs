using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EWireColor
{
    None = -1,
    Red,
    Blue,
    Yellow,
    Magenta
}

public class FixWiringTesk : QuestObjects
{
    [SerializeField]
    private List<LeftWire> mLeftWires;

    [SerializeField]
    private List<RightWire> mRightWires;

    private LeftWire mSelectedWire;

    private void OnEnable()
    {
        ResetWire();

        List<int> numberPool = new List<int>();

        for (int ii = 0; ii < 4; ii++)
        {
            numberPool.Add(ii);
        }

        int idx = 0;
        while (numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mLeftWires[idx++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }

        for (int ii = 0; ii < 4; ii++)
        {
            numberPool.Add(ii);
        }

        idx = 0;
        while (numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mRightWires[idx++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas.SetActive(false);
        Quest_Available = true;

        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);
            if (hit.collider != null)
            {
                var left = hit.collider.GetComponentInParent<LeftWire>();
                if (left != null)
                {
                    mSelectedWire = left;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (mSelectedWire != null)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponentInParent<RightWire>();
                        if (right != null)
                        {
                            mSelectedWire.SetTarget(Input.mousePosition, -50f); //offset
                            mSelectedWire.ConnectWire(right);
                            right.ConnectWire(mSelectedWire);
                            mSelectedWire = null;
                            CheckCompleteTask();
                            return;
                        }
                    }
                }

                mSelectedWire.ResetTarget();
                mSelectedWire.DisconnectWire();
                mSelectedWire = null;
                CheckCompleteTask();
            }
        }

        if (mSelectedWire != null)
        {
            mSelectedWire.SetTarget(Input.mousePosition, -15f); //offset
        }
    }

    void ResetWire() //전선 상태 초기화
    {
        for (int ii = 0; ii < mLeftWires.Count; ii++)
        {
            mLeftWires[ii].ResetTarget();
            mLeftWires[ii].DisconnectWire();
        }
    }

    private void CheckCompleteTask()
    {//전선이 다 연결되었는지 확인하는 함수
        bool isAllComplete = true;
        foreach (var wire in mLeftWires)
        {
            if (!wire.IsConnected)
            {
                isAllComplete = false;
                break;
            }
        }

        if (isAllComplete)
        {
            Debug.Log("미션성공");
            QuestComp();
        }
    }

    public override void QuestComp()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        OnOffQuestCanvas(false);
        OnOffCanvas(false);
        Quest_Available = false;
    }

    public override void OnOffCanvas(bool OnOff)
    {
        base.OnOffCanvas(OnOff);
    }

    public override void OnOffQuestCanvas(bool OnOff)
    {
        base.OnOffQuestCanvas(OnOff);
    }

    public override void CloseBtnFunc()
    {
        OnOffQuestCanvas(false);
        ResetWire();
    }
}
