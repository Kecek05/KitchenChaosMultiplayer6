using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame += KitchenGameMultiplayer_OnFailedToJoinGame;
        KitchenGameLobby.Instance.OnCreateLobbyStarted += KitchenGameLobby_OnCreateLobbyStarted;
        KitchenGameLobby.Instance.OnCreateLobbyFailed += KitchenGameLobby_OnCreateLobbyFailed;
        KitchenGameLobby.Instance.OnJoinLobbyStarted += KitchenGameLobby_OnJoinLobbyStarted;
        KitchenGameLobby.Instance.OnJoinLobbyFailed += KitchenGameLobby_OnJoinLobbyFailed;
        KitchenGameLobby.Instance.OnQuickJoinLobbyFailed += KitchenGameLobby_OnQuickJoinLobbyStarted;
        Hide();
    }
    private void KitchenGameLobby_OnQuickJoinLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Could not find a Lobby to Quick Join!");
    }   

    private void KitchenGameLobby_OnJoinLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to join lobby!");
    }

    private void KitchenGameLobby_OnJoinLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Joining lobby...");
    }

    private void KitchenGameLobby_OnCreateLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Creating lobby...");
    }

    private void KitchenGameLobby_OnCreateLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to create lobby!");
    }

    private void ShowMessage(string message)
    {
        Show();
        messageText.text = message;
    }

    private void KitchenGameMultiplayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        if(NetworkManager.Singleton.DisconnectReason == "")
        {
            ShowMessage("Failed to connect");
        } else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame -= KitchenGameMultiplayer_OnFailedToJoinGame;
        KitchenGameLobby.Instance.OnCreateLobbyStarted -= KitchenGameLobby_OnCreateLobbyStarted;
        KitchenGameLobby.Instance.OnCreateLobbyFailed -= KitchenGameLobby_OnCreateLobbyFailed;
        KitchenGameLobby.Instance.OnJoinLobbyStarted -= KitchenGameLobby_OnJoinLobbyStarted;
        KitchenGameLobby.Instance.OnJoinLobbyFailed -= KitchenGameLobby_OnJoinLobbyFailed;
        KitchenGameLobby.Instance.OnQuickJoinLobbyFailed -= KitchenGameLobby_OnQuickJoinLobbyStarted;
    }
}
