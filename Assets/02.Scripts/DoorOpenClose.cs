using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    bool Dopenclose;

    public GameObject LDoor;
    Vector3 LDSPos;
    Vector3 LDEPos;
    public GameObject RDoor;
    Vector3 RDSPos;
    Vector3 RDEPos;

    Vector3 LIngPos;
    Vector3 RIngPos;

    float test = 0.0f;
    bool first = false;
    // Start is called before the first frame update
    void Start()
    {
        Dopenclose = true;
        LDSPos = LDoor.transform.localPosition;
        RDSPos = RDoor.transform.localPosition;
        LDEPos = LDoor.transform.localPosition;
        LDEPos.x = 3.0f;
        RDEPos = RDoor.transform.localPosition;
        RDEPos.x = -9.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!first)
            return;

        if (Dopenclose == true)
        {
            if (test <= 1.0f)
            {
                test += Time.deltaTime;
            }

            LDoor.transform.localPosition = Vector3.Lerp(LIngPos, LDEPos, test);
            RDoor.transform.localPosition = Vector3.Lerp(RIngPos, RDEPos, test);


            Debug.Log(LDoor.transform.localPosition);
            Debug.Log(RDoor.transform.localPosition);
        }

        if (Dopenclose == false)
        {
            if (test <= 1.0f)
            {
                test += Time.deltaTime;
            }

            LDoor.transform.localPosition = Vector3.Lerp(LIngPos, LDSPos, test);
            RDoor.transform.localPosition = Vector3.Lerp(RIngPos, RDSPos, test);

            Debug.Log(LDoor.transform.localPosition);
            Debug.Log(RDoor.transform.localPosition);
        }

        LIngPos = LDoor.transform.localPosition;
        RIngPos = RDoor.transform.localPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!first)
            first = true;

        if(test >= 1.0f)
            test = 0.0f;

        Dopenclose = true;
        Debug.Log(Dopenclose);
    }

    private void OnTriggerExit(Collider other)
    {
        if (test >= 1.0f)
            test = 0.0f;

        Dopenclose = false;
        Debug.Log(Dopenclose);
    }
}
