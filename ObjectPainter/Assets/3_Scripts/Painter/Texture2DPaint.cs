using UnityEngine;
using UnityEngine.UI;

namespace Painter
{
    [System.Serializable]
    public class Texture2DPaint : IPaint
    {
        [SerializeField]
        private Texture2D texture;

        public void PaintMaterial(Material material)
        {
            material.mainTexture = texture;
        }

        public void PaintImage(Image image)
        {
            image.material.mainTexture = texture;
        }

        public void UndoPaintMaterial(Material material)
        {
            material.mainTexture = null;
        }
    }
}
