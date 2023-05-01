using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Testing : MonoBehaviour
{
    [SerializeField] private Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());
            GridPosition start = new GridPosition(0, 0);

            List<GridPosition> gridPositions = Pathfinding.Instance.FindPath(start, mouseGridPosition);

            for (int i = 0; i < gridPositions.Count - 1; i++)
            {
                Debug.DrawLine(
                    LevelGrid.Instance.GetWorldPosition(gridPositions[i]),
                    LevelGrid.Instance.GetWorldPosition(gridPositions[i + 1]),
                    Color.green,
                    10f
                );
            }
        }
    }
}
