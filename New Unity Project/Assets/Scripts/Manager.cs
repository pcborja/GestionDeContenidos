using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class Manager : MonoBehaviour
{
    public List<Panel> panels;
    public AutoCompleteComboBox comboBox;
    public GamePopup gamePopup;
    public ProfilePopup profilePopup;
    public HelpPopup helpPopup;
    public SettingsPopup settingsPopup;
    public Star[] stars;
    
    private AudioSource _audioSource;
    private List<GameVisual> _gameVisuals = new List<GameVisual>();
    private Game[] _gamesFound;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
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

        SetVolume();
    }

    public void FindGameName(string gameName)
    {
        var gameSelected = _gamesFound.First(x => x.gameName == gameName);
        OpenGamePopup(gameSelected);
    }

    public void OpenGamePopup(Game gameSelected)
    {
        ClosePopups();
        gamePopup.SetPopup(gameSelected, this);
    }

    public void ClosePopups()
    {
        EventsManager.TriggerEvent(Constants.TypeOfEvent.ClosePopup);
    }

    public void OnHelpButton()
    {
        ClosePopups();
        helpPopup.SetPopup(this);
    }

    public void OnProfileButton()
    {
        ClosePopups();
        profilePopup.SetPopup(this);
    }
    
    public void OnSettingsButton()
    {
        ClosePopups();
        settingsPopup.SetPopup(this);
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

    public void ChangeVolume(float sliderValue)
    {
        _audioSource.volume = sliderValue;
    }
    
    private void SetVolume()
    {
        settingsPopup.SetVolume(_audioSource.volume);
    }
}
