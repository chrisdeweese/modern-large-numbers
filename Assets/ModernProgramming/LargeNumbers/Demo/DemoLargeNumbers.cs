using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ModernProgramming
{
    public class DemoLargeNumbers : MonoBehaviour
    {
        public Text numberLabel;
        public Toggle shortStringToggle;
        public InputField addLargeInput;
        public InputField subLargeInput;
        public InputField assignInput;

        private LargeNumber myLargeNumber = new LargeNumber();
        private bool useShortString;

        
        // Refreshes the UI on start.
        private void Start()
        {
            UpdateUI();
        }

        // This is the toggle for showing short or long number strings.
        public void onToggle_ShortString()
        {
            useShortString = shortStringToggle.isOn;
            
            UpdateUI();
        }

        // Adds one to the large number.
        public void onClick_AddOne()
        {
            myLargeNumber.AddOne();
            UpdateUI();
        }

        // Subtracts one from the large number.
        public void onClick_SubtractOne()
        {
            myLargeNumber.SubtractOne();
            UpdateUI();
        }

        // Takes the inputted large number and adds it to our large number.
        public void onClick_AddLargeNumber()
        {
            // Create a new empty large number.
            LargeNumber numberToAdd = new LargeNumber();
            
            // Convert the input field's string into a large number.
            numberToAdd = numberToAdd.StringToLargeNumber(addLargeInput.text);
            
            // Adds the converted number to our large number.
            myLargeNumber.AddLargeNumber(numberToAdd);
            
            UpdateUI();
        }

        // Takes the inputted large number and subtracts it from our large number.
        public void onClick_SubtractLargeNumber()
        {
            // Create a new empty large number.
            LargeNumber numberToSub = new LargeNumber();
            
            // Convert the input field's string into a large number.
            numberToSub = numberToSub.StringToLargeNumber(subLargeInput.text);
            
            // Subtracts the converted number to our large number.
            myLargeNumber.SubtractLargeNumber(numberToSub);
            
            UpdateUI();
        }

        public void onClick_AssignNumber()
        {
            // Create a new empty large number.
            LargeNumber numberToAssign = new LargeNumber();
            
            // Convert the input field's string into a large number.
            numberToAssign = numberToAssign.StringToLargeNumber(assignInput.text);
            
            // Assign the converted number to our large number.
            myLargeNumber.Assign(numberToAssign);
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            // Converts the large number into either a short string or long string.
            numberLabel.text = useShortString
                ? myLargeNumber.LargeNumberToShortString()
                : myLargeNumber.LargeNumberToString();
        }
    }
}