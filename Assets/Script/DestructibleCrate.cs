using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestructibleCrate : MonoBehaviour
{
    [SerializeField] private Transform crateDestroyedPrefab;
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
        Transform crateDestroyedTransform = Instantiate(crateDestroyedPrefab, transform.position, transform.rotation);
        ApplyExplosionToChildren(crateDestroyedTransform, 100f, transform.position, 10f);
        Destroy(gameObject);
        onAnyDestroyed?.Invoke(this, EventArgs.Empty);
    }

    private void ApplyExplosionToChildren(Transform root, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        foreach(Transform child in root)
        {
            if(child.TryGetComponent<Rigidbody>(out Rigidbody childRigidBody))
            {
                childRigidBody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
            }
            ApplyExplosionToChildren(child, explosionForce, explosionPosition, explosionRadius);
        }
    }
}
