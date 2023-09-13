using GFA.TPS.UI.Pagination;
using UnityEngine;

namespace GFA.TPS.UI.Pages
{
    public class ArmoryPage : Page
    {
        [SerializeField]
        private Animator _animator;
        protected override void OnOpened()
        {
            _animator.Play("Armory");
        }

        protected override void OnClosed()
        {
        }
    }
}
