using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGame : MonoBehaviour
{
    [SerializeField]
    GameObject gameObject;
    private FadeManager fadeManager;

    // Start is called before the first frame update
    void Start()
    {
        fadeManager = gameObject.GetComponent<FadeManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            fadeManager.StartFade();
        }
    }
}
