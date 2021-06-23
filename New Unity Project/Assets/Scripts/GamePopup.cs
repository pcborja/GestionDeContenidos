using TMPro;
using UnityEngine.UI;

public class GamePopup : Popup
{
    public Image gameImage;
    public Image[] gameScreenshots;
    public Image defaultScreenshot;
    public TextMeshProUGUI rating;
    public TextMeshProUGUI ratingAmount;
    public TextMeshProUGUI gameName;
    public TextMeshProUGUI gameDesc;

    public void SetPopup(Game game, Manager manager)
    {
        base.SetPopup(manager);

        gameName.text = game.name;
        gameDesc.text = game.description;
        rating.text = game.punctuation.ToString();
        ratingAmount.text = "(" + game.punctuationAmount + ")";

        if (game.gameScreenshots.Length == 0)
        {
            for (var i = 0; i < 4; i++)
                gameScreenshots[i].sprite = defaultScreenshot.sprite;
        }
        else
        {
            for (var i = 0; i < game.gameScreenshots.Length; i++)
            {
                if (i < gameScreenshots.Length)
                    gameScreenshots[i].sprite = game.gameScreenshots[i] ? game.gameScreenshots[i] : defaultScreenshot.sprite;
            }
        }

        if (game.gameSprite)
            gameImage.sprite = game.gameSprite;
    }

    protected override void ClosePopup(params object[] data)
    {
        if (!_manager) return;
        
        TurnOffStars(_manager.stars);
        base.ClosePopup(data);
    }

    private void TurnOffStars(Star[] stars)
    {
        foreach (var star in stars)
        {
            star.TurnYellow(false);
        }
    }
}
