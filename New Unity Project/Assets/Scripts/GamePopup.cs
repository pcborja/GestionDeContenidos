using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePopup : MonoBehaviour
{
    public Image gameImage;
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
