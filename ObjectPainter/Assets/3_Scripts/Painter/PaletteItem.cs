using UnityEngine;
using UnityEngine.UI;

namespace Painter
{
    [RequireComponent(typeof(Button))]
    public class PaletteItem : MonoBehaviour
    {
        public int id;

        public Button selectPaintButton;
        public Image paintIcon;

        private const string shaderName = "UI/Default";

        public void InitialiseMaterial()
        {
            paintIcon.material = new Material(Shader.Find(shaderName));
        }
    }
}
