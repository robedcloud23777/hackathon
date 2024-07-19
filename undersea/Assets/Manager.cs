using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public void ctrl()
    {
        SceneManager.LoadScene("2");
    }

    public void dtrl()
    {
        SceneManager.LoadScene("3");
    }
}
