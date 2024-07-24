using System.Collections;
using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스를 추가합니다.
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // TextMeshProUGUI 컴포넌트를 참조합니다.
    public Canvas canvas; // Canvas 컴포넌트를 참조합니다.
    public Canvas canvas2; // Canvas 컴포넌트를 참조합니다.
    public float delayBetweenMessages = 2f; // 문장 간의 시간 간격
    public string[] messages; // 출력할 문장들
    public Image canvasImage;
    public Player player;
    public Image[] heart;
    public TextMeshProUGUI Dna;
    public Monkfish monk;
    public Image[] heart2;
    public Monkfish Monk;

    public float timeLimit = 180f;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        canvas2.enabled = false;
        if (textMeshPro != null && canvas != null && messages.Length > 0)
        {
            StartCoroutine(DisplayMessages());
        }
        StartCoroutine(TimerCountdown());
    }

    private void Update()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].enabled = i < player.hp;
        }
        if(player.DNA >= 1)
        {
            Dna.text = "DNA : 3 / 3";
        }
        for (int i = 0; i < heart2.Length; i++)
        {
            heart2[i].enabled = i < monk.hp/5;
        }
    }

    private IEnumerator TimerCountdown()
    {
        float remainingTime = timeLimit;

        while (remainingTime > 0)
        {
            // 남은 시간을 시:분:초 형식으로 변환
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            // 텍스트 업데이트
            timerText.text = $"{minutes:D2}:{seconds:D2}";

            yield return new WaitForSeconds(1f); // 1초 대기
            remainingTime -= 1f; // 남은 시간 감소
        }

        // 타이머 종료 후 수행할 작업
        timerText.text = "00:00"; // 타이머가 0이 되었을 때 표시
    }

    private IEnumerator DisplayMessages()
    {
        foreach (string message in messages)
        {
            textMeshPro.text = message; // 현재 문장을 설정합니다.
            yield return new WaitForSeconds(delayBetweenMessages); // 문장 간의 지연 시간
        }

        textMeshPro.text = ""; // 모든 메시지 출력 후 텍스트를 지웁니다.
        canvas2.enabled = true;
        canvas.enabled = false; // Canvas를 비활성화합니다.
    }
}
