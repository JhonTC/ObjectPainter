using UnityEngine;
using UnityEngine.UI;

namespace Painter
{
    public interface IPaint
    {
        public void PaintMaterial(Material material);

        public void PaintImage(Image image);

        public void UndoPaintMaterial(Material material);
    }
}
