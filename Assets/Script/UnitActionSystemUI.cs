using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UnitActionSystemUI : MonoBehaviour
{
    
    [SerializeField] private Transform actionButtonPrefab;
    [SerializeField] private Transform actionButtonContainerTransform;

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChange += UnitActionSystem_OnSelectedUnitChanged;

        CreateUnitActionButtons();
    }


    private void CreateUnitActionButtons()
    {
        foreach(Transform button in actionButtonContainerTransform)
        {
            Destroy(button.gameObject);
        }
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        
        foreach(BaseAction baseAction in selectedUnit.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainerTransform);
            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButtonUI.SetBaseAcition(baseAction);
        }
    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e) {
        {
            CreateUnitActionButtons();
        }
    }
}
