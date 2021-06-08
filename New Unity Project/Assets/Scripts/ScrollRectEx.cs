using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
 
public class ScrollRectEx : ScrollRect {
 
    private bool routeToParent = false;
 
 
    /// <summary>
    /// Do action for all parents
    /// </summary>
    private void DoForParents<T>(Action<T> action) where T:IEventSystemHandler
    {
        Transform parent = transform.parent;
        while(parent != null) {
            foreach(var component in parent.GetComponents<Component>()) {
                if(component is T)
                    action((T)(IEventSystemHandler)component);
            }
            parent = parent.parent;
        }
    }
 
    /// <summary>
    /// Always route initialize potential drag event to parents
    /// </summary>
    public override void OnInitializePotentialDrag (PointerEventData eventData)
    {
        DoForParents<IInitializePotentialDragHandler>((parent) => { parent.OnInitializePotentialDrag(eventData); });
        base.OnInitializePotentialDrag (eventData);
    }
 
    /// <summary>
    /// Drag event
    /// </summary>
    public override void OnDrag (UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (routeToParent)
        {
            var delta = new Vector2(eventData.scrollDelta.x, eventData.scrollDelta.y * -1);
            eventData.scrollDelta = delta;
            
            var delta2 = new Vector2(eventData.delta.x, eventData.delta.y * -1);
            eventData.delta = delta2;
            
            var delta3 = new Vector2(eventData.pressPosition.x, eventData.pressPosition.y * -1);
            eventData.pressPosition = delta3;
            
            DoForParents<IDragHandler>((parent) => { parent.OnDrag(eventData); });
        }
        else
            base.OnDrag (eventData);
    }
 
    /// <summary>
    /// Begin drag event
    /// </summary>
    public override void OnBeginDrag (UnityEngine.EventSystems.PointerEventData eventData)
    {
        if(!horizontal && Math.Abs (eventData.delta.x) > Math.Abs (eventData.delta.y))
            routeToParent = true;
        else if(!vertical && Math.Abs (eventData.delta.x) < Math.Abs (eventData.delta.y))
            routeToParent = true;
        else
            routeToParent = false;
 
        if(routeToParent)
            DoForParents<IBeginDragHandler>((parent) => { parent.OnBeginDrag(eventData); });
        else
            base.OnBeginDrag (eventData);
    }
 
    /// <summary>
    /// End drag event
    /// </summary>
    public override void OnEndDrag (UnityEngine.EventSystems.PointerEventData eventData)
    {
        if(routeToParent)
            DoForParents<IEndDragHandler>((parent) => { parent.OnEndDrag(eventData); });
        else
            base.OnEndDrag (eventData);
        routeToParent = false;
    }
}
 