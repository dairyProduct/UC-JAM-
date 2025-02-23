using System;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class GameSingleton : MonoBehaviour
{
    #region Singleton

    // Static reference to the singleton instance of GameWizard
    private static GameSingleton _instance;
    public static GameSingleton Instance => _instance;

    private void Awake()
    {
        // Ensure only one instance of GameSingleton exists
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            NonSingletonAwake();
            // Don't destroy GameSingleton on scene changes
            DontDestroyOnLoad(_instance.gameObject);
        }
    }

    #endregion
    
    [HideInInspector] public InputManager InputManager;

    private void NonSingletonAwake()
    {
        InputManager = GetComponent<InputManager>();
    }
}