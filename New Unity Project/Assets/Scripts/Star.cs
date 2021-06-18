using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public GameObject yellowImage;
    
    private Manager _manager;

    public void Start()
    {
        TurnYellow(false);
    }

    public void TurnYellow(bool active)
    {
        yellowImage.SetActive(active);
    }

    public void SetStar(Manager manager)
    {
        _manager = manager;
    }

    public void OnStarClicked()
    {
        _manager.OnStarClicked(this);
    }
}
