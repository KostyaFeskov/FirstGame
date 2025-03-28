﻿using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Meta.Locations
{
    public class Pin : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        
        [SerializeField] private Color _currentLevel;
        [SerializeField] private Color _passedLevel;
        [SerializeField] private Color _closedLevel;

        public void Initialize(int levelNumber, PinType pinType, UnityAction clickCallback) {
            _text.text = $"Level {levelNumber}";

            _image.color = pinType switch {
                PinType.Current => _currentLevel,
                PinType.Passed => _passedLevel,
                PinType.Close => _closedLevel,
            };
            
            _button.onClick.AddListener(() => clickCallback?.Invoke());

        }
    }
}