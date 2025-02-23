using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public InputPackage LatestInputPackage;
    // TODO: FOR NOW WE USE UPDATE. CHANGE TO NEW INPUT SYSTEM LATER

    public enum InputValues
    {
        None,
        Left,
        Right,
        Up,
        Down,
        Jump,
        Ability1,
        Ability2,
        Ability3
    }
    
    public struct InputPackageElement
    {
        public InputValues InputValue;
        public float Magnitude;
    }
    
    public struct InputPackage
    {
        public List<InputPackageElement> InputElements;

        public InputPackage(List<InputPackageElement> inputElements)
        {
            InputElements = inputElements;
        }

        public bool Contains(InputValues inputValue, out InputPackageElement element)
        {
            element = new();
            if (InputElements == null)
            {
                return false;
            }
            
            foreach (var inputElement in InputElements)
            {
                if (inputValue == inputElement.InputValue)
                {
                    element = inputElement;
                    return true;
                }
            }

            return false;
        }
    }

    private void Update()
    {
        List<InputPackageElement> inputPackages = new List<InputPackageElement>();

        float horiz = Input.GetAxis("Horizontal");
        if (horiz > 0)
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Right, Magnitude = horiz });
        }
        else if (horiz < 0)
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Left, Magnitude = horiz });
        }

        float vert = Input.GetAxis("Vertical");
        if (vert < 0)
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Down, Magnitude = vert });
        }
        else if (vert > 0)
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Up, Magnitude = vert });
        }

        if (Input.GetButtonDown("Jump"))
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Jump, Magnitude = 1.0f });
        }

        if (Input.GetButtonDown("Fire1"))
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Ability1, Magnitude = 1.0f });
        }

        if (Input.GetButtonDown("Fire2"))
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Ability2, Magnitude = 1.0f });
        }

        if (Input.GetButtonDown("Fire3"))
        {
            inputPackages.Add(new InputPackageElement { InputValue = InputValues.Ability3, Magnitude = 1.0f });
        }

        LatestInputPackage = new InputPackage (inputPackages);
    }
}