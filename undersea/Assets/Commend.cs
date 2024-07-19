using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command : MonoBehaviour
{
    public InputField inputField;
    private bool isNearAgi = false;

    void Start()
    {
        inputField.gameObject.SetActive(false); // 처음에는 InputField를 비활성화
    }

    void Update()
    {
        // 플레이어가 Agi 근처에 있을 때 InputField를 활성화
        if (isNearAgi)
        {
            inputField.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return)) // Enter 키를 감지
            {
                ExecuteCommand();
            }
        }
        else
        {
            inputField.gameObject.SetActive(false);
        }
    }

    void ExecuteCommand()
    {
        string command = inputField.text;

        switch (command.ToLower())
        {
            case "attack":
                Debug.Log("공격");
                inputField.text = ""; // 입력 필드를 비움
                break;
            case "flash":
                Debug.Log("눈뽕!!!");
                inputField.text = ""; // 입력 필드를 비움
                break;
            case "kill":
                Debug.Log("죽어라!!");
                inputField.text = ""; // 입력 필드를 비움
                break;
            default:
                Debug.Log("다시한번 입력해주세요.");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Agi"))
        {
            isNearAgi = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Agi"))
        {
            isNearAgi = false;
        }
    }
}


