using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField]
    private int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // HP�擾
    public int GetHP()
    {
        return HP;
    }

    // HP����
    public void DecreaseHP(int decreaseNum)
    {
        HP -= decreaseNum;
    }
}
