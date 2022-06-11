using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDraw : MonoBehaviour
{
    [SerializeField]
    GameObject[] Heart = new GameObject[5];

    int a = 5;

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Heart[i].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (a)
        {
            case 4:
                Heart[4].SetActive(false);
                break;
            case 3:
                Heart[4].SetActive(false);
                Heart[3].SetActive(false);
                break;
            case 2:
                Heart[4].SetActive(false);
                Heart[3].SetActive(false);
                Heart[2].SetActive(false);
                break;
            case 1:
                Heart[4].SetActive(false);
                Heart[3].SetActive(false);
                Heart[2].SetActive(false);
                Heart[1].SetActive(false);
                break;
            case 0:
                Heart[4].SetActive(false);
                Heart[3].SetActive(false);
                Heart[2].SetActive(false);
                Heart[1].SetActive(false);
                Heart[0].SetActive(false);
                break;
        }
       
        if(Input.GetKey(KeyCode.R))
        {
            a = 4;
        }
    }
}
