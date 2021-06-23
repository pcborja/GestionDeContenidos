using UnityEngine.UI;

public class SettingsPopup : Popup
{
    public Slider slider;
    
    public void ChangeVolume(Slider slider)
    {
        _manager.ChangeVolume(slider.value);
    }

    public void SetVolume(float audioSourceVolume)
    {
        slider.value = audioSourceVolume;
    }
}
