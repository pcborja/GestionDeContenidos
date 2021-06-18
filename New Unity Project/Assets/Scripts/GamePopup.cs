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

    public void Start()
    {
        EventsManager.SubscribeToEvent(Constants.TypeOfEvent.ClosePopup, ClosePopup);
        ClosePopup();
    }
    
    public void SetGame(Game game)
    {
        gameObject.SetActive(true);

        gameName.text = game.name;
        gameDesc.text = game.description;
        rating.text = game.punctuation.ToString();

        for (var i = 0; i < game.gameScreenshots.Length; i++)
        {
            if (i < gameScreenshots.Length && game.gameScreenshots[i].sprite)
                gameScreenshots[i].sprite = game.gameScreenshots[i].sprite;
        }

        if (game.gameImage)
            gameImage.sprite = game.gameImage.sprite;
    }

    private void ClosePopup(params object[] data)
    {
        gameObject.SetActive(false);
    }
    
    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
