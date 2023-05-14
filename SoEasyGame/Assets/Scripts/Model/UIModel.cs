using UnityEngine;

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
                Debug.Log(_score);
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
                _gauge = Mathf.Clamp(value, 0, 100);
                Debug.Log(_gauge);
            }
        }
    }
}