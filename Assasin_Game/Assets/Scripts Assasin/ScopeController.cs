using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeController : MonoBehaviour
{
    [SerializeField]
    private GameObject scopePrefab;

    private GameObject scopeInstance;
    private Camera mainCamera;

    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ToggleScope();
        }

        if(scopeInstance != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            scopeInstance.transform.position = worldPosition;
             if (Input.GetMouseButtonDown(0))
            {
                CheckForTargetHit();
            }
        }


    }

    private void CheckForTargetHit()
    {
        Vector3 scopePosition = scopeInstance.transform.position;
        Collider2D hitCollider = Physics2D.OverlapCircle(scopePosition, 0.1f);

        if( hitCollider != null)
        {
            if(hitCollider.CompareTag("Target"))
            {
                Destroy(hitCollider.gameObject);
            }
        }
    }

    private void ToggleScope()
    {
        if(scopeInstance == null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            scopeInstance = Instantiate(scopePrefab, worldPosition, Quaternion.identity);
            scopeInstance.transform.position = worldPosition;
        }
        else
        {
            Destroy(scopeInstance);
        }
    }
}
