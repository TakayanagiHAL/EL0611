using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����

public class ScoreDraw : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText; //���_�̕����̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + ScoreManager.GetCurrentScore().ToString();
    }
}
