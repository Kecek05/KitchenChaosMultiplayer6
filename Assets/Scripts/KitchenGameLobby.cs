using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class KitchenGameLobby : MonoBehaviour
{

    public static KitchenGameLobby Instance { get; private set; }


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
            await UnityServices.InitializeAsync();

            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        }

    }
}
