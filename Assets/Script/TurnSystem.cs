using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { get; private set; }
    public event EventHandler OnTurnChanged;
    private int turnNumber = 1;
    
    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("More than one TurnSystem " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void NextTurn()
    {
        turnNumber++;
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }
}
