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
        inputField.gameObject.SetActive(false); // ó������ InputField�� ��Ȱ��ȭ
    }

    void Update()
    {
        // �÷��̾ Agi ��ó�� ���� �� InputField�� Ȱ��ȭ
        if (isNearAgi)
        {
            inputField.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return)) // Enter Ű�� ����
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
                Debug.Log("����");
                inputField.text = ""; // �Է� �ʵ带 ���
                break;
            case "flash":
                Debug.Log("����!!!");
                inputField.text = ""; // �Է� �ʵ带 ���
                break;
            case "kill":
                Debug.Log("�׾��!!");
                inputField.text = ""; // �Է� �ʵ带 ���
                break;
            default:
                Debug.Log("�ٽ��ѹ� �Է����ּ���.");
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


