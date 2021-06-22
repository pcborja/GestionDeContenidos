using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePopup : MonoBehaviour
{
    public Image gameImage;
    public Image[] gameScreenshots;
    public TextMeshProUGUI rating;
    public TextMeshProUGUI gameName;
    public TextMeshProUGUI gameDesc;

    private Manager _manager;
    
    public void Start()
    {
        EventsManager.SubscribeToEvent(Constants.TypeOfEvent.ClosePopup, ClosePopup);
        ClosePopup();
    }
    
    public void SetGame(Game game, Manager manager)
    {
        _manager = manager;
        gameObject.SetActive(true);

        gameName.text = game.name;
        gameDesc.text = game.description;
        rating.text = game.punctuation.ToString();

        for (var i = 0; i < game.gameScreenshots.Length; i++)
        {
            if (i < gameScreenshots.Length && game.gameScreenshots[i])
                gameScreenshots[i].sprite = game.gameScreenshots[i];
        }

        if (game.gameSprite)
            gameImage.sprite = game.gameSprite;
    }

    private void ClosePopup(params object[] data)
    {
        TurnOffStars(_manager.stars);
        gameObject.SetActive(false);
    }

    private void TurnOffStars(Star[] stars)
    {
        foreach (var star in stars)
        {
            star.TurnYellow(false);
        }
    }
    
    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
