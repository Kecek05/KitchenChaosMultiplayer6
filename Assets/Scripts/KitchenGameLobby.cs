using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using UnityEngine;
using Unity.Services.Lobbies.Models;

public class KitchenGameLobby : MonoBehaviour
{

    public static KitchenGameLobby Instance { get; private set; }

    //private Lobby joinedLobby;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeUnityAuthentication();
    }

    private async void InitializeUnityAuthentication()
    {
        if(UnityServices.State != ServicesInitializationState.Initialized)
        {
            InitializationOptions initializationOptions = new InitializationOptions();

            initializationOptions.SetProfile(Random.Range(0, 10000).ToString());

            await UnityServices.InitializeAsync(initializationOptions);

            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        }

    }

    //public async void CreateLobby(string lobbyName, bool isPrivate)
    //{
    //    //joinedLobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, isPrivate, KitchenGameMultiplayer.MAX_PLAYER_AMOUNT, new CreateLobbyOptions
    //    //{
    //    //    IsPrivate = isPrivate,
    //    //});
    //}

}
