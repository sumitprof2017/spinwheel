using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        this.gameObject.GetComponent<Button>().onClick.AddListener(Spin);
    }
    private void Awake()
    {
        this.gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;

    }

    // Update is called once per frame
    void Spin()
    {
        SpinningWheel.Instance.SpinWheelButtonClick();
    }
}
