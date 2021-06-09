using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Game", menuName = "Game")]
public class Game : ScriptableObject
{
    public string gameName;
    public Image gameImage;
}
