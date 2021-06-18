using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class Manager : MonoBehaviour
{
    public List<Panel> panels;
    public AutoCompleteComboBox comboBox;
    public GamePopup popup;
    public Star[] stars;
    
    private List<GameVisual> _gameVisuals = new List<GameVisual>();
    private Game[] _gamesFound;

    public void Start()
    {
        foreach (var gameVisual in panels.SelectMany(panel => panel.gamesVisuals))
        {
            _gameVisuals.Add(gameVisual);
        }
        _gamesFound = Resources.LoadAll<Game>("");

        for (var i = 0; i < _gamesFound.Length; i++)
        {
            if (i < _gameVisuals.Count)
            {
                comboBox.AddItem(_gamesFound[i].gameName);
                _gameVisuals[i].SetupGame(_gamesFound[i]);
            }
        }

        foreach (var star in stars)
        {
            star.SetStar(this);
        }
    }

    public void FindGameName(string gameName)
    {
        var gameSelected = _gamesFound.First(x => x.gameName == gameName);
        OpenGamePopup(gameSelected);
    }

    public void OpenGamePopup(Game gameSelected)
    {
        popup.SetGame(gameSelected);
    }

    public void CloseGamePopup()
    {
        EventsManager.TriggerEvent(Constants.TypeOfEvent.ClosePopup);
    }

    public void OnMyGamesButton()
    {
        CloseGamePopup();
    }

    public void OnProfileButton()
    {
        CloseGamePopup();
    }
    
    public void OnSettingsButton()
    {
        CloseGamePopup();
    }

    public void OnStarClicked(Star starCliked)
    {
        var starFound = false;
        
        foreach (var star in stars)
        {
            if (starFound)
            {
                star.TurnYellow(false);
                continue;
            }
            
            if (star != starCliked)
                star.TurnYellow(true);

            if (star == starCliked)
            {
                star.TurnYellow(true);
                starFound = true;
            }
        }
    }
}
