using _Code.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Code
{
    public class UIEye : SingletonMono<UIEye>
    {
        [SerializeField] private Image image;
        
        public void ShowAnim()
        {
            var seq = DOTween.Sequence();
            seq.Append(image.DOColor(new Color(1, 1, 1, 1), .03f));
            seq.Append(image.DOColor(new Color(1, 1, 1, 0), .03f));
        }
    }
}