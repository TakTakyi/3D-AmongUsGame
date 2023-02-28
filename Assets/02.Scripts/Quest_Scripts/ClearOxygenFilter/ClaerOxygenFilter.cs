using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaerOxygenFilter : QuestObjects
{

    // Start is called before the first frame update
    void Start()
    {
        m_UseUICanvas.SetActive(false);
        Quest_Available = true;

        if (m_ClostBtn != null)
        {
            m_ClostBtn.onClick.AddListener(CloseBtnFunc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(Input.mousePosition);

        //    //int layerMask = 1 << LayerMask.NameToLayer("Leave");
        //    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    //RaycastHit hit;
        //    //if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        //    //{
        //    //    Debug.Log(hit.collider.name);
        //    //}
        //}
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
