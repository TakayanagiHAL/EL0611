using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] float fadeTime;
    float timer;
    bool isFade = false;
    bool isFadeIn = false;
    Image image;
    public sceneManage sceneManage;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade)
        {
            
            if (isFadeIn)
            {
                Debug.Log("fadeIn");
                timer -= Time.deltaTime;
                image.color = new Color(image.color.r, image.color.g, image.color.b,timer/fadeTime);
                if (timer <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                timer += Time.deltaTime;
                image.color = new Color(image.color.r, image.color.g, image.color.b, timer / fadeTime);
                if (timer >= fadeTime)
                {
                    DontDestroyOnLoad(gameObject);
                    sceneManage.LoadNext();
                    isFadeIn = true;
                }
            }
        }
    }

    public void StartFade()
    {
        if (isFade) return;
        timer = 0.0f;
        isFade = true;
     
    }
}
