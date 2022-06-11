using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float elapsedTime = 0.0f;
    bool counterFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        counterFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (counterFlag == true)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void SetCounterFlag(bool flag)
    {
        counterFlag = flag;
    }

    public float GetCurrentTime()
    {
        return elapsedTime;
    }
}
