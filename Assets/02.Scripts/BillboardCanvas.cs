using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    private Transform tr;
    private Transform mainCameraTr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        //���������� �ִ� ���� ī�޶��� Transform ������Ʈ�� ����
        mainCameraTr = Camera.main.transform;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void LateUpdate()
    {   //���ʿ��� ����� ��� ������ �ʰ� Hp�ٰ� ĳ���͸� ���� �ٴѴ�
        //---- HpBar BillBoard ���
        tr.forward = mainCameraTr.forward;
        //Quad�� ���� ����� ������ �ϴ� ���
        //---- HpBar BillBoard ���
    }
}
