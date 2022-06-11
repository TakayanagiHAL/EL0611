using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.CompareScore();
        ScoreManager.SetCurrentScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
