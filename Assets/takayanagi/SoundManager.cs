using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    //BGM管理-------------------------------
    [System.Serializable]
    public class BGM_Data
    {
        public string BGM_Name;
        public AudioClip BGM_Clip;
        [SerializeField]
        public float Volume = 1.0f;
    }

    [SerializeField]
    private BGM_Data[] BGM_Datas;

    //SE管理--------------------------------
    [System.Serializable]
    public class SE_Data
    {
        public string SE_Name;
        public AudioClip SE_Clip;
        [SerializeField]
        public float Volume = 1.0f;
    }

    [SerializeField]
    private SE_Data[] SE_Datas;

    //ボリューム関連------------------------
    public float BGM_Volume = 0.1f;
    public float SE_Volume = 0.1f;
    public bool Mute = false;

    //Audio Souce---------------------------
    private AudioSource[] BGM_Source = new AudioSource[2];
    private AudioSource[] SE_Source = new AudioSource[10];

    //Dictionary----------------------------
    private Dictionary<string, BGM_Data> BGM_Dictionary = new Dictionary<string, BGM_Data>();
    private Dictionary<string, SE_Data> SE_Dictionary = new Dictionary<string, SE_Data>();

    void Awake()
    {
        //シングルトン＆シーン遷移しても破棄されない
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        //BGM用AudioSource
        BGM_Source[0] = gameObject.AddComponent<AudioSource>();
        BGM_Source[1] = gameObject.AddComponent<AudioSource>();

        //BGM_Dictionaryにセット
        foreach (var bgmData in BGM_Datas)
        {
            BGM_Dictionary.Add(bgmData.BGM_Name, bgmData);
        }

        //SE用AudioSource
        for (var i = 0; i < SE_Source.Length; ++i)
        {
            SE_Source[i] = gameObject.AddComponent<AudioSource>();
        }

        //SE_Dictionaryにセット
        foreach (var seData in SE_Datas)
        {
            SE_Dictionary.Add(seData.SE_Name, seData);
        }

        //ボリューム設定
        BGM_Source[0].volume = BGM_Volume;
        BGM_Source[1].volume = BGM_Volume;

        for (var i = 0; i < SE_Source.Length; ++i)
        {
            SE_Source[i].volume = SE_Volume;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (BGM_Source[0].isPlaying == false)
        {
            BGM_Source[0].Stop();
            BGM_Source[0].clip = null;
        }
        if (BGM_Source[1].isPlaying == false)
        {
            BGM_Source[1].Stop();
            BGM_Source[1].clip = null;
        }

        for (var i = 0; i < SE_Source.Length; ++i)
        {
            if (SE_Source[i].isPlaying == false)
            {
                SE_Source[i].Stop();
                SE_Source[i].clip = null;
            }
        }
    }

    //未使用のBGM用AudioSourceの取得 すべて使用中はnullを返却
    private AudioSource GetUnusedBGMAudioSource()
    {
        if (BGM_Source[0].isPlaying == false)
        {
            BGM_Source[1].Stop();
            BGM_Source[1].clip = null;
            return BGM_Source[0];
        }

        else if (BGM_Source[1].isPlaying == false)
        {
            BGM_Source[0].Stop();
            BGM_Source[0].clip = null;
            return BGM_Source[1];
        }
        return null;
    }

    //未使用のSE用AudioSourceの取得 すべて使用中はnullを返却
    private AudioSource GetUnusedSEAudioSource()
    {
        foreach (var seSource in SE_Source)
        {
            if (seSource.isPlaying == false)
            {
                return seSource;
            }
        }

        return null;
    }


    //指定された名前で登録されたBGMを再生
    public void PlayBGM(string name)
    {
        if (BGM_Dictionary.TryGetValue(name, out var bgmData))
        {
            //見つかったら再生
            PlayBGM(bgmData.BGM_Clip,bgmData.Volume);
        }
        else
        {
            Debug.LogWarning($"その名前は登録されていません：{name}");
        }
    }

    //指定されたBGMを未使用のAudioSourceで再生
    public void PlayBGM(AudioClip clip,float vol)
    {
        var audioSource = GetUnusedBGMAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = BGM_Volume * vol;
        audioSource.Play();
    }

    //指定された名前で登録されたSEを再生
    public void PlaySE(string name)
    {
        if (SE_Dictionary.TryGetValue(name, out var seData))
        {
            //見つかったら再生
            PlaySE(seData.SE_Clip,seData.Volume);
        }
        else
        {
            Debug.LogWarning($"その名前は登録されていません：{name}");
        }
    }

    //指定されたSEを未使用のAudioSourceで再生
    public void PlaySE(AudioClip clip, float vol)
    {
        var audioSource = GetUnusedSEAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = clip;
        audioSource.volume = SE_Volume * vol;
        audioSource.Play();
    }


    //BGM停止
    public void StopBGM(string name)
    {
        if (BGM_Dictionary.TryGetValue(name, out var bgmData))
        {
            //見つかって再生中なら停止
            if (BGM_Source[0].isPlaying == true && BGM_Source[0].clip == bgmData.BGM_Clip)
            {
                BGM_Source[0].Stop();
                BGM_Source[0].clip = null;
            }

            if (BGM_Source[1].isPlaying == true && BGM_Source[1].clip == bgmData.BGM_Clip)
            {
                BGM_Source[1].Stop();
                BGM_Source[1].clip = null;
            }
        }
    }

    //全BGM停止
    public void StopAllBGM()
    {
        BGM_Source[0].Stop();
        BGM_Source[0].clip = null;

        BGM_Source[1].Stop();
        BGM_Source[1].clip = null;
    }

    //SE停止
    public void StopAllSE()
    {
        foreach (AudioSource source in SE_Source)
        {
            source.Stop();
            source.clip = null;
        }
    }
}
