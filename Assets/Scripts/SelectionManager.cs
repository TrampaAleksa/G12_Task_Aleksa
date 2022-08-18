using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private GameObject _selectedObj;
    public static SelectionManager Instance;
    
    public GameObject SelectedObj
    {
        get => _selectedObj;
        set => _selectedObj = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}