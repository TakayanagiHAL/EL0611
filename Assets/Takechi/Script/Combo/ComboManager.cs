using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    // �ő�R���{��
    public static int g_MaxCombo = 0;

    // ���݂̃R���{��
    public static int g_CurrentCombo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // ���݂̃X�R�A�Z�b�g
    public static void SetCurrentCombo(int combo)
    {
        g_CurrentCombo = combo;
    }

    // ���݂̃X�R�A�ǉ�
    public static void AddCurrentScore(int combo)
    {
        g_CurrentCombo += combo;
    }

    // ���݂̃X�R�A�擾
    public static int GetCurrentScore()
    {
        return g_CurrentCombo;
    }

    // �ő�X�R�A�擾
    public static int GetMaxScore()
    {
        return g_MaxCombo;
    }


    // �ő�X�R�A�Ɣ�r���ăX�R�A���傫����΍X�V
    // �X�V���Ă�����true��Ԃ�
    public static bool CompareScore()
    {
        // ����
        bool judge = false;

        // �X�R�A���X�V���Ă�����t���O�𗧂Ă�
        if (g_CurrentCombo > g_MaxCombo)
        {
            judge = true;
        }

        return judge;
    }
}
