using UnityEngine;

public class Popup : MonoBehaviour
{
    protected Manager _manager;
    
    public void Start()
    {
        EventsManager.SubscribeToEvent(Constants.TypeOfEvent.ClosePopup, ClosePopup);
        ClosePopup();
    }
    
    public virtual void SetPopup(Manager manager)
    {
        _manager = manager;
        gameObject.SetActive(true);
    }
    
    protected virtual void ClosePopup(params object[] data)
    {
        gameObject.SetActive(false);
    }
    
    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
