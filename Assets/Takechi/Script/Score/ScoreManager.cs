using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 最大スコア
    public static int g_MaxScore = 0;

    // 現在のスコア
    public static int g_CurrentScore = 0;

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        LoadScore();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 現在のスコアセット
    public static void SetCurrentScore(int score)
    {
        g_CurrentScore = score;
    }

    // 現在のスコア追加
    public static void AddCurrentScore(int score)
    {
        g_CurrentScore += score;
    }

    // 現在のスコア取得
    public static int GetCurrentScore()
    {
        return g_CurrentScore;
    }

    // 最大スコア取得
    public static int GetMaxScore()
    {
        return g_MaxScore;
    }


    // 最大スコアと比較してスコアが大きければ更新
    // 更新していたらtrueを返す
    public static bool CompareScore()
    {
        // 判定
        bool judge = false;

        // スコアを更新していたらフラグを立てる
        if(g_CurrentScore > g_MaxScore)
        {
            // スコアのセーブ
            SaveScore();
            judge = true;
            g_MaxScore = g_CurrentScore;
        }

        return judge;
    }

    // スコアのセーブ
    public static void SaveScore()
    {
        // スコアを保存
        PlayerPrefs.SetInt("MAXSCORE", g_MaxScore);
        PlayerPrefs.Save();
    }

    public static void LoadScore()
    {
        // スコアのロード
        g_CurrentScore = PlayerPrefs.GetInt("MAXSCORE", 0);
    }
}
