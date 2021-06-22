using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameVisual : MonoBehaviour
{
    public TextMeshProUGUI gameName;
    public Image gameImage;
    private Game _game;

    public void SetupGame(Game game)
    {
        _game = game;
        gameName.text = game.gameName;
        
        if (game.gameSprite)
            gameImage.sprite = game.gameSprite;
    }

    public void OnGameClicked()
    {
        FindObjectOfType<Manager>().OpenGamePopup(_game);
    }
}
