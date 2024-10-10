using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatbotController1 : MonoBehaviour
{
    public Text chatText;  // 답변이 출력될 텍스트 UI 요소
    private Dictionary<string, string> faq;  // 질문과 답변을 매핑할 딕셔너리

    void Start()
    {
        // 질문과 답변 매핑
        faq = new Dictionary<string, string>()
        {
            {"How to move furniture?", "You can move furniture by dragging it with your finger."},
            {"How to rotate furniture?", "Tap on the furniture to see rotation options."},
            {"How to delete furniture?", "Select the item and press the delete button."}
        };
    }

    // 질문 버튼을 클릭하면 호출되는 함수
    public void OnQuestionClicked(string question)
    {
        if (faq.ContainsKey(question))
        {
            chatText.text = faq[question];  // 해당 질문에 맞는 답변을 텍스트 필드에 출력
        }
        else
        {
            chatText.text = "No answer available.";  // 질문이 없을 때 출력할 기본 메시지
        }
    }
}