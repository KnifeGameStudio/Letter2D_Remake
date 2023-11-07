using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ContinueGame : MonoBehaviour
{
    public void ContinueTheGame()
    {
        SceneManager.LoadScene(GameObject.Find("Stage_Count").GetComponent<Save_Stage>().stage);
    }
    
    
}
