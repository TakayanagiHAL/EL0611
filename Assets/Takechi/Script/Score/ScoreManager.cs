using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // �ő�X�R�A
    public static int g_MaxScore = 0;

    // ���݂̃X�R�A
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

    // ���݂̃X�R�A�Z�b�g
    public static void SetCurrentScore(int score)
    {
        g_CurrentScore = score;
    }

    // ���݂̃X�R�A�ǉ�
    public static void AddCurrentScore(int score)
    {
        g_CurrentScore += score;
    }

    // ���݂̃X�R�A�擾
    public static int GetCurrentScore()
    {
        return g_CurrentScore;
    }

    // �ő�X�R�A�擾
    public static int GetMaxScore()
    {
        return g_MaxScore;
    }


    // �ő�X�R�A�Ɣ�r���ăX�R�A���傫����΍X�V
    // �X�V���Ă�����true��Ԃ�
    public static bool CompareScore()
    {
        // ����
        bool judge = false;

        // �X�R�A���X�V���Ă�����t���O�𗧂Ă�
        if(g_CurrentScore > g_MaxScore)
        {
            // �X�R�A�̃Z�[�u
            SaveScore();
            judge = true;
            g_MaxScore = g_CurrentScore;
        }

        return judge;
    }

    // �X�R�A�̃Z�[�u
    public static void SaveScore()
    {
        // �X�R�A��ۑ�
        PlayerPrefs.SetInt("MAXSCORE", g_MaxScore);
        PlayerPrefs.Save();
    }

    public static void LoadScore()
    {
        // �X�R�A�̃��[�h
        g_CurrentScore = PlayerPrefs.GetInt("MAXSCORE", 0);
    }
}
