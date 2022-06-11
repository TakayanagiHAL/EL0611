using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public struct EnemyStatus
    {
        public float speed;
        public int score;
        public int attack;
        public int life;
    }
    [SerializeField]
    private float[] m_EnemySpeed = new float[4];
    [SerializeField]
    private int[] m_EnemyScore = new int[4];
    [SerializeField]
    private int[] m_EnemyAttack = new int[4];
    [SerializeField]
    private int[] m_EnemyLife = new int[4];
    [SerializeField]
    GameObject m_SpawnEnemy;
    [SerializeField]
    private Vector3[] m_LeftSpawnPosition = new Vector3[3];
    [SerializeField]
    private Vector3[] m_RightSpawnPosition = new Vector3[3];
    [SerializeField]
    private float m_BaseEnemySpeed;
    private float m_Speed;
    [SerializeField]
    private float m_Accelerate;
    [SerializeField]
    private float m_SpawnInterval;

    private float m_TotalTime;

    private float m_SpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        m_SpawnTime = Time.time;
        m_TotalTime = 0;
        m_Speed = m_BaseEnemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        m_TotalTime += Time.deltaTime;
        m_Speed += m_Accelerate * Time.deltaTime;
        if (Time.time - m_SpawnTime > m_SpawnInterval)
        {
            int index = Random.Range(0, 6);
            int type = (index % 3) != 2 ? (index % 3) : Random.Range(2, 4);
            GameObject enemy = GameObject.Instantiate(m_SpawnEnemy, index > 2 ? m_RightSpawnPosition[index - 3] : m_LeftSpawnPosition[index], Quaternion.identity);
            enemy.GetComponent<Enemy>().Init(type, index < 3, m_EnemySpeed[type] * m_Speed, m_EnemyLife[type], m_EnemyScore[type],m_EnemyAttack[type]);

            m_SpawnTime = Time.time;
        }

        if(m_TotalTime > 10.0f)
        {
            m_TotalTime = 0.0f;
            m_SpawnInterval *= 0.8f;
        }
        
    }
}
