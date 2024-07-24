using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void ToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void ToAnimation()
    {
        SceneManager.LoadScene("Animation");
    }
    public void ToOption()
    {
        SceneManager.LoadScene("Option");
    }

    public void ToPlay()
    {
        SceneManager.LoadScene("Play");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                // �����Ϳ��� ���� ���� ���� �÷��� ��带 �����մϴ�.
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    // ����� ���ӿ����� ���ø����̼��� �����մϴ�.
                    Application.Quit();
        #endif
    }
}
