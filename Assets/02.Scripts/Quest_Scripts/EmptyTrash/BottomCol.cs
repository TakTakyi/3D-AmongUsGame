using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll) //��ư Ŭ���� ������ ������Ʈ ����
    {
        //Debug.Log(coll.gameObject.name);

        if (coll.tag == "Leave")
        {
            coll.gameObject.SetActive(false);
        }
    }
}
