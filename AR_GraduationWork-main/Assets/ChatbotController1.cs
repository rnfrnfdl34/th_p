using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatbotController1 : MonoBehaviour
{
    public Text chatText;  // �亯�� ��µ� �ؽ�Ʈ UI ���
    private Dictionary<string, string> faq;  // ������ �亯�� ������ ��ųʸ�

    void Start()
    {
        // ������ �亯 ����
        faq = new Dictionary<string, string>()
        {
            {"How to move furniture?", "You can move furniture by dragging it with your finger."},
            {"How to rotate furniture?", "Tap on the furniture to see rotation options."},
            {"How to delete furniture?", "Select the item and press the delete button."}
        };
    }

    // ���� ��ư�� Ŭ���ϸ� ȣ��Ǵ� �Լ�
    public void OnQuestionClicked(string question)
    {
        if (faq.ContainsKey(question))
        {
            chatText.text = faq[question];  // �ش� ������ �´� �亯�� �ؽ�Ʈ �ʵ忡 ���
        }
        else
        {
            chatText.text = "No answer available.";  // ������ ���� �� ����� �⺻ �޽���
        }
    }
}