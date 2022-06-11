using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    private Sprite[] m_Sprites = new Sprite[14];
    private float m_ChangeInterval = 0.1f;
    private float m_ChangeStartTime;
    private int m_Index;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_Sprites[0];
        m_ChangeStartTime = Time.time;
        m_Index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - m_ChangeStartTime >= m_ChangeInterval)
        {

            m_Index++;
            m_ChangeStartTime = Time.time;
            if(m_Index >= 14)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = m_Sprites[m_Index];
            }
        }
    }
}
