using UnityEngine;

public class CharacterSelectPlayer : MonoBehaviour
{
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
