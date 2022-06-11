using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    [SerializeField] FadeManager FadeManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad0)){
            SoundManager.instance.PlayBGM("タイトル");
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SoundManager.instance.PlayBGM("ゲーム");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SoundManager.instance.PlayBGM("ゲームオーバー");
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SoundManager.instance.PlaySE("ボタン");
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SoundManager.instance.PlaySE("ヒット");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            FadeManager.StartFade();
            Debug.Log("FadeStart");
        }

    }
}
