using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    public Image ItemImg = null;

    // Start is called before the first frame update
    void Start()
    {
        int xPos = Random.Range(-120, 240);
        int yPos = Random.Range(-230, 230);
        ItemImg.rectTransform.anchoredPosition = new Vector2(xPos, yPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TrashHoll")
        {
            ItemImg.gameObject.SetActive(false);
        }
    }

    
}
