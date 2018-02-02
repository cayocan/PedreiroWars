using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGameTemp : MonoBehaviour
{
    public void restartGame()
    {
		SceneManager.LoadScene("PrototipeScene", LoadSceneMode.Single);
    }
}
