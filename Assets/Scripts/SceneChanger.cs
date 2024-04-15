using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    
    public void Change()
    {
        SceneManager.LoadScene(sceneIndex);
        
        Time.timeScale = 1;
    }
}
