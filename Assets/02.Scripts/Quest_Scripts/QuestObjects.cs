using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
    public GameObject m_Canvas;
    //public bool OnOffCV = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void QuestComp()
    {

    }

    public virtual void OnOffCanvas(bool OnOff)
    {
        if (OnOff == true)
        {
            m_Canvas.SetActive(true);
        }
        else
        {
            m_Canvas.SetActive(false);
        }
    }
}
