using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    [SerializeField] float moveX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sPos = transform.position;
        sPos.x += moveX * Time.deltaTime;
        transform.position = sPos;   
    }

}
