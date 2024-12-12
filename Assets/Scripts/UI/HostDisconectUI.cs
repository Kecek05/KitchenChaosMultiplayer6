using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using QFSW.QC;
using System;

public class HostDisconectUI : MonoBehaviour
{

    [SerializeField] private Button playAgainButton;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {

        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;

        Hide();
    }


    private void NetworkManager_OnClientDisconnectCallback(ulong clientId)
    {
        //if(clientId == NetworkManager.ServerClientId)
        //{
        //    //Host disconnected
        //    Show();

        //}
        if (!NetworkManager.Singleton.IsServer)
        {
            //Host disconnected
            Show();

        }
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
        if(NetworkManager.Singleton != null)
            NetworkManager.Singleton.OnClientDisconnectCallback -= NetworkManager_OnClientDisconnectCallback;
    }
}
