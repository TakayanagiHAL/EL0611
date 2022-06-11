using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDraw : MonoBehaviour
{
    [SerializeField]
    GameObject[] Heart = new GameObject[5];

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

    }
}
