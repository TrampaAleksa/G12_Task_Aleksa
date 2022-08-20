using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject nullSelectedObject; // Initial reference to avoid Null Reference problems
    
    private GameObject _selectedObj;
    public static SelectionManager Instance;
    
    public GameObject SelectedObj
    {
        get => _selectedObj; //todo - Localize references to selected obj
        set => _selectedObj = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            _selectedObj = nullSelectedObject;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}