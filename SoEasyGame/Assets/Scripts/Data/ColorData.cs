using UnityEngine;

namespace Data
{
    public class ColorData
    {
        public enum ColorState
        {
            Cyan,
            Green,
            Yellow,
            ColorType
        }
        
        // Gem의 Color를 저장하는 배열
        public static Color[] Colors = new[]
        {
            Color.cyan, 
            Color.green, 
            Color.yellow
        };
    }
}