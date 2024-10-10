using UnityEngine;
using UnityEngine.UI;

public class ChatbotController : MonoBehaviour
{
    public GameObject chatPanel;
    private bool isPanelVisible = false;

    public void ToggleChatPanel()
    {
        isPanelVisible = !isPanelVisible;
        chatPanel.SetActive(isPanelVisible);  // �г��� ���̰ų� ����� ���
    }
}
