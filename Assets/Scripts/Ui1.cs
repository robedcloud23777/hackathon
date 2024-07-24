using System.Collections;
using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스를 추가합니다.
using UnityEngine.UI;

public class Ui1 : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // TextMeshProUGUI 컴포넌트를 참조합니다.
    public Canvas canvas; // Canvas 컴포넌트를 참조합니다.
    public float delayBetweenMessages = 2f; // 문장 간의 시간 간격
    public string[] messages; // 출력할 문장들

    private void Start()
    {
        if (textMeshPro != null && canvas != null && messages.Length > 0)
        {
            StartCoroutine(DisplayMessages());
        }
    }

    private IEnumerator DisplayMessages()
    {
        foreach (string message in messages)
        {
            textMeshPro.text = message; // 현재 문장을 설정합니다.
            yield return new WaitForSeconds(delayBetweenMessages); // 문장 간의 지연 시간
        }

        textMeshPro.text = ""; // 모든 메시지 출력 후 텍스트를 지웁니다.
    }
}
