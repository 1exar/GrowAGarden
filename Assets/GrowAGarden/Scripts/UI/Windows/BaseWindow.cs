using UnityEngine;

namespace GrowAGarden.Scripts.UI.Windows
{
    public class BaseWindow : MonoBehaviour
    {

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}