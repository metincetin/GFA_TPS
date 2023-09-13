using GFA.TPS.Mediators;
using GFA.TPS.UI.Pagination;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GFA.TPS.UI.Pages
{
    public class GamePage : Page
    {
        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private Animator _animator;
        
        protected override void OnOpened()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _animator.Play("Game");
        }

        protected override void OnClosed()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene("Loading");
        }
    }
}
