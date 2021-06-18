using System.Collections.Generic;

public class EventsManager
{
    public delegate void EventReceiver(params object[] parameterContainer);
    private static Dictionary<Constants.TypeOfEvent, EventReceiver> _events;

    public static void SubscribeToEvent(Constants.TypeOfEvent eventType, EventReceiver listener)
    {
        if (_events == null)
            _events = new Dictionary<Constants.TypeOfEvent, EventReceiver>();

        if (!_events.ContainsKey(eventType))
            _events.Add(eventType, null);

        _events[eventType] += listener;
    }

    public static void UnsubscribeToEvent(Constants.TypeOfEvent eventType, EventReceiver listener)
    {
        if (_events == null) return;
        if (_events.ContainsKey(eventType))
            _events[eventType] -= listener;
    }

    public static void TriggerEvent(Constants.TypeOfEvent eventType)
    {
        TriggerEvent(eventType, null);
    }

    public static void TriggerEvent(Constants.TypeOfEvent eventType, params object[] parametersWrapper)
    {
        if (_events == null)
        {
            UnityEngine.Debug.LogWarning("No events subscribed");
            return;
        }

        if (!_events.ContainsKey(eventType)) return;
        if (_events[eventType] != null)
            _events[eventType](parametersWrapper);
    }

    public static void ClearEvents()
    {
        _events?.Clear();
    }
}