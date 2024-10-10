using UnityEngine;
using UnityEngine.UI;

public class ChatbotController : MonoBehaviour
{
    public GameObject chatPanel;
    private bool isPanelVisible = false;

    public void ToggleChatPanel()
    {
        isPanelVisible = !isPanelVisible;
        chatPanel.SetActive(isPanelVisible);  // 패널을 보이거나 숨기는 기능
    }
}
