using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftWire : MonoBehaviour
{
    public EWireColor WireColor { get; private set; }

    public bool IsConnected { get; private set; }

    [SerializeField]
    private List<Image> mWireImages;

    [SerializeField]
    private Image mLightImage;

    [SerializeField]
    private RightWire mConnectedWire;

    [SerializeField]
    private RectTransform mWirebody;

    //private LeftWire mSelectedwire;

    //[SerializeField]
    //private float offset = 15f;

    private Canvas mGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mGameCanvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void SetTarget(Vector3 targetPosition, float offset)
    {
        float angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position,
                targetPosition - transform.position);
        float distance = (Vector2.Distance(mWirebody.transform.position, targetPosition) + offset);
        mWirebody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        mWirebody.sizeDelta = new Vector2(distance * (1 / mGameCanvas.transform.localScale.x), mWirebody.sizeDelta.y);
    }

    public void ResetTarget()
    {
        mWirebody.localRotation = Quaternion.Euler(Vector3.zero);
        mWirebody.sizeDelta = new Vector2(0f, mWirebody.sizeDelta.y);
    } 

    public void SetWireColor(EWireColor wireColor)
    {
        WireColor = wireColor;
        Color color = Color.black;
        switch (WireColor)
        {
            case EWireColor.Red:
                color = Color.red;
                break;
            case EWireColor.Blue:
                color = Color.blue;
                break;
            case EWireColor.Yellow:
                color = Color.yellow;
                break;
            case EWireColor.Magenta:
                color = Color.magenta;
                break;
        }

        foreach (var image in mWireImages)
        {
            image.color = color;
        }
    }

    public void ConnectWire(RightWire rightWire)
    {
        if (mConnectedWire != null && mConnectedWire != rightWire)
        {
            mConnectedWire.DisconnectWire(this);
            mConnectedWire = null;
        }

        mConnectedWire = rightWire;
        if (mConnectedWire.WireColor == WireColor)
        {
            mLightImage.color = Color.yellow;
            IsConnected = true;
        }
    }

    public void DisconnectWire()
    {
        if (mConnectedWire != null)
        {
            mConnectedWire.DisconnectWire(this);
            mConnectedWire = null;
        }
        mLightImage.color = Color.gray;
        IsConnected = false;
    }
}
