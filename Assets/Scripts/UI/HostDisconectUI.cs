using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using QFSW.QC;

public class HostDisconectUI : MonoBehaviour
{

    [SerializeField] private Button playAgainButton;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(() => {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {

        NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;

            //NetworkManager.Singleton.OnConnectionEvent += NetworkManager_OnConnectionEvent;

        Hide();
    }


    private void NetworkManager_OnClientDisconnectCallback(ulong clientId)
    {
        print(clientId);

        if (clientId == NetworkManager.ServerClientId)
        {
            //Host disconnected
            Show();
            print("Host Disconected");
        }
    }

    //private void NetworkManager_OnConnectionEvent(NetworkManager arg1, ConnectionEventData arg2)
    //{
    //    if (arg2.EventType.Equals(ConnectionEvent.ClientDisconnected))
    //    {
    //        // Disconnected
    //        if (arg2.ClientId == NetworkManager.ServerClientId && this != null)
    //        {
    //            //Host disconnected
    //            HostDisconnectedServerRpc();
    //            print("Disconected");
    //        }
    //    }
    //}

        //[ServerRpc]
        //private void HostDisconnectedServerRpc()
        //{
        //    HostDisconnectedClientRpc();
        //}

        //[ClientRpc]
        //private void HostDisconnectedClientRpc()
        //{
        //    Show();
        //}

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
