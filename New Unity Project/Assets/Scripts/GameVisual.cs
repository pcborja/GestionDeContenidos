using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameVisual : MonoBehaviour
{
    public TextMeshProUGUI gameName;
    public Image gameImage;
    
    public void SetupGame(Game game)
    {
        gameName.text = game.gameName;
        
        if (game.gameImage)
            gameImage.sprite = game.gameImage.sprite;
    }
}
