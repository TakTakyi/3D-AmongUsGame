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

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name);

        if (coll.tag == "Leave")
        {
            Destroy(coll.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name);

        if (coll.tag == "Leave")
        {
            Destroy(coll.gameObject);
        }
    }
}
