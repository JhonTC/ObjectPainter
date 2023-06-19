using UnityEngine;
using UnityEngine.UI;

namespace Painter
{
    [System.Serializable]
    public class ColourPaint : IPaint
    {
        [SerializeField]
        private Color colour;

        public void PaintMaterial(Material material)
        {
            material.color = colour;
        }

        public void PaintImage(Image image)
        {
            image.color = colour;
        }

        public void UndoPaintMaterial(Material material)
        {
            material.color = Color.white;
        }
    }
}


