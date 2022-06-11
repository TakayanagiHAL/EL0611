using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    //BGM�Ǘ�-------------------------------
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

    //SE�Ǘ�--------------------------------
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

    //�{�����[���֘A------------------------
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
        //�V���O���g�����V�[���J�ڂ��Ă��j������Ȃ�
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        //BGM�pAudioSource
        BGM_Source[0] = gameObject.AddComponent<AudioSource>();
        BGM_Source[1] = gameObject.AddComponent<AudioSource>();

        //BGM_Dictionary�ɃZ�b�g
        foreach (var bgmData in BGM_Datas)
        {
            BGM_Dictionary.Add(bgmData.BGM_Name, bgmData);
        }

        //SE�pAudioSource
        for (var i = 0; i < SE_Source.Length; ++i)
        {
            SE_Source[i] = gameObject.AddComponent<AudioSource>();
        }

        //SE_Dictionary�ɃZ�b�g
        foreach (var seData in SE_Datas)
        {
            SE_Dictionary.Add(seData.SE_Name, seData);
        }

        //�{�����[���ݒ�
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

    //���g�p��BGM�pAudioSource�̎擾 ���ׂĎg�p����null��ԋp
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

    //���g�p��SE�pAudioSource�̎擾 ���ׂĎg�p����null��ԋp
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


    //�w�肳�ꂽ���O�œo�^���ꂽBGM���Đ�
    public void PlayBGM(string name)
    {
        if (BGM_Dictionary.TryGetValue(name, out var bgmData))
        {
            //����������Đ�
            PlayBGM(bgmData.BGM_Clip,bgmData.Volume);
        }
        else
        {
            Debug.LogWarning($"���̖��O�͓o�^����Ă��܂���F{name}");
        }
    }

    //�w�肳�ꂽBGM�𖢎g�p��AudioSource�ōĐ�
    public void PlayBGM(AudioClip clip,float vol)
    {
        var audioSource = GetUnusedBGMAudioSource();
        if (audioSource == null) return; //�Đ��ł��܂���ł���
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = BGM_Volume * vol;
        audioSource.Play();
    }

    //�w�肳�ꂽ���O�œo�^���ꂽSE���Đ�
    public void PlaySE(string name)
    {
        if (SE_Dictionary.TryGetValue(name, out var seData))
        {
            //����������Đ�
            PlaySE(seData.SE_Clip,seData.Volume);
        }
        else
        {
            Debug.LogWarning($"���̖��O�͓o�^����Ă��܂���F{name}");
        }
    }

    //�w�肳�ꂽSE�𖢎g�p��AudioSource�ōĐ�
    public void PlaySE(AudioClip clip, float vol)
    {
        var audioSource = GetUnusedSEAudioSource();
        if (audioSource == null) return; //�Đ��ł��܂���ł���
        audioSource.clip = clip;
        audioSource.volume = SE_Volume * vol;
        audioSource.Play();
    }


    //BGM��~
    public void StopBGM(string name)
    {
        if (BGM_Dictionary.TryGetValue(name, out var bgmData))
        {
            //�������čĐ����Ȃ��~
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

    //�SBGM��~
    public void StopAllBGM()
    {
        BGM_Source[0].Stop();
        BGM_Source[0].clip = null;

        BGM_Source[1].Stop();
        BGM_Source[1].clip = null;
    }

    //SE��~
    public void StopAllSE()
    {
        foreach (AudioSource source in SE_Source)
        {
            source.Stop();
            source.clip = null;
        }
    }
}
