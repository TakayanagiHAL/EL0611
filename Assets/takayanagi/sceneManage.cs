using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManage : MonoBehaviour
{
    [SerializeField] string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
