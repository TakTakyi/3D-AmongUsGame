using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    bool Dopenclose;

    public GameObject LDoor;
    Vector3 LDPos;
    public GameObject RDoor;
    Vector3 RDPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Dopenclose = false;
        LDPos = LDoor.transform.position;
        RDPos = RDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dopenclose == true)
        {
            if (LDoor.transform.position.y >= -1.0f && RDoor.transform.position.y >= -1.0f)
            {
                Debug.Log(LDoor.transform.position);
                Debug.Log(RDoor.transform.position);

                LDPos.y = -3.5f;
                RDPos.y = -3.5f;
                
                LDoor.transform.Translate(LDPos, Space.Self);
                RDoor.transform.Translate(RDPos, Space.Self);
            }
        }

        if (Dopenclose == false)
        {
            if (LDoor.transform.position.y <= -3.5f && RDoor.transform.position.y <= -3.5f)
            {
                Debug.Log(LDoor.transform.position);
                Debug.Log(RDoor.transform.position);

                LDPos.y = 0.0f;
                RDPos.y = 0.0f;

                LDoor.transform.Translate(LDPos, Space.Self);
                RDoor.transform.Translate(RDPos, Space.Self);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Dopenclose = true;
        Debug.Log(Dopenclose);
    }

    private void OnTriggerExit(Collider other)
    {
        Dopenclose = false;
        Debug.Log(Dopenclose);
    }
}
