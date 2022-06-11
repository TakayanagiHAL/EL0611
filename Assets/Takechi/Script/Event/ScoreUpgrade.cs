using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpgrade : MonoBehaviour
{
    [SerializeField]
    private Texture2D tex;

    private Sprite mySprite;
    private SpriteRenderer sr;

    private bool IsPopUp = false;
    private float elapsedTime = 0.0f;

    private float finishTime = 0.5f;

    void Awake()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);

        transform.position = new Vector3(1.5f, 1.5f, 0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPopUp == true)
        {
            transform.localScale = new Vector3(0.1f, 0.1f) * elapsedTime * 20;
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= finishTime)
            {
                IsPopUp = false;
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            PopUp();
        }
    }

    public void PopUp()
    {
        IsPopUp = true;
        sr.sprite = mySprite;
        elapsedTime = 0.0f;
        transform.localScale = new Vector3(0.0f, 0.0f);
    }
}
