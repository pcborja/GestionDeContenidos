using UnityEngine;

public class ProfileGame : MonoBehaviour
{
    public Game game;

    private Manager _manager;
    
    public void Start()
    {
        _manager = FindObjectOfType<Manager>();
    }

    public void OpenProfileGame()
    {
        _manager.OpenGamePopup(game);
    }
}
