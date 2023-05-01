using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestructibleCrate : MonoBehaviour
{
    public static event EventHandler onAnyDestroyed;
    private GridPosition gridPosition;

    private void Start() {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
    }

    public GridPosition GetGridPosition() {
        return gridPosition;
    }
    public void Damage()
    {
        Destroy(gameObject);
        onAnyDestroyed?.Invoke(this, EventArgs.Empty);
    }
}
