using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatButtonHelper : MonoBehaviour
{
    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);      
    }
}
