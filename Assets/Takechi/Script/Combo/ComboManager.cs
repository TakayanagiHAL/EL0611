using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    // 最大コンボ数
    public static int g_MaxCombo = 0;

    // 現在のコンボ数
    public static int g_CurrentCombo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 現在のスコアセット
    public static void SetCurrentCombo(int combo)
    {
        g_CurrentCombo = combo;
    }

    // 現在のスコア追加
    public static void AddCurrentScore(int combo)
    {
        g_CurrentCombo += combo;
    }

    // 現在のスコア取得
    public static int GetCurrentScore()
    {
        return g_CurrentCombo;
    }

    // 最大スコア取得
    public static int GetMaxScore()
    {
        return g_MaxCombo;
    }


    // 最大スコアと比較してスコアが大きければ更新
    // 更新していたらtrueを返す
    public static bool CompareScore()
    {
        // 判定
        bool judge = false;

        // スコアを更新していたらフラグを立てる
        if (g_CurrentCombo > g_MaxCombo)
        {
            judge = true;
        }

        return judge;
    }
}
