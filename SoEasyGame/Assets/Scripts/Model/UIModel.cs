using UnityEngine;
using Data;

namespace Model
{
    public static class UIModel
    {
        private static float _score;

        public static float Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        private static float _gauge;

        public static float Gauge
        {
            get
            {
                return _gauge;
            }
            set
            {
                _gauge = Mathf.Clamp(value, 0, 1);
            }
        }

        private static ColorData.ColorState _currentColorState;

        public static ColorData.ColorState CurrrentColorState
        {
            get
            {
                return _currentColorState;
            }
            set
            {
                _currentColorState = value;
            }
        }
    }
}