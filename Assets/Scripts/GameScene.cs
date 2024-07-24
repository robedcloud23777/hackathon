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
                // 에디터에서 실행 중일 때는 플레이 모드를 종료합니다.
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    // 빌드된 게임에서는 애플리케이션을 종료합니다.
                    Application.Quit();
        #endif
    }
}
