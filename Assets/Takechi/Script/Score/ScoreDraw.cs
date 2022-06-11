using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI機能を扱うときに追記する

public class ScoreDraw : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText; //得点の文字の変数

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
