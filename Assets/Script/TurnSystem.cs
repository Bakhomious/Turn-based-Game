using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { get; private set; }
    public event EventHandler OnTurnChanged;
    private int turnNumber = 1;

    private bool isPlayerTurn = true;
    
    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("More than one TurnSystem " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Unit.OnAnyActionPointsChanged += Unit_OnAnyActionPointsChanged;
    }
    public void NextTurn()
    {
        turnNumber++;
        isPlayerTurn = !isPlayerTurn;
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    private void Unit_OnAnyActionPointsChanged (object sender, EventArgs e)
    {
        int unitCount = UnitManager.Instance.GetFriendlyUnitList().Count;
        foreach (Unit unit in UnitManager.Instance.GetFriendlyUnitList())
        {
            if (unit.GetActionPoints() == 0)
            {
                unitCount--;
            }
            Debug.Log("Unit: " + unit.name + " AP: " + unit.GetActionPoints());
        }

        if (unitCount == 0 && isPlayerTurn)
        {
            NextTurn();
        }

        Debug.Log("Unit count: " + unitCount);
    }
}
