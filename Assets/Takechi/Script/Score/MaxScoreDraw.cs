using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScoreDraw : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "�ő�X�R�A:" + ScoreManager.GetCurrentScore().ToString();
    }
}
