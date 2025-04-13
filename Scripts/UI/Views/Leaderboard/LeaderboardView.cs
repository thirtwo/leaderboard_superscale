// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using DG.Tweening;
using System;
using Thirtwo.MVVM;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace Thirtwo.UI
{
    public class LeaderboardView : View<LeaderboardVM>, IView
    {
        private Vector2 initialLayoutSize;
        [SerializeField] private RectTransform layout;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button tapToStartButton;
        [SerializeField] private GameObject leaderboardPanel;
        [SerializeField] private RectTransform layoutPanel;
        public RectTransform Layout => layout;

        Sequence sequence;

        [Inject]
        private void Construct(LeaderboardVM leaderboardVM)
        {
            viewModel = leaderboardVM;
        }
        #region Unity Standart Callbacks
        private void Start()
        {
            exitButton.onClick.AddListener(() => Hide());
            tapToStartButton.onClick.AddListener(() => Display());
            initialLayoutSize = layoutPanel.sizeDelta;

        }
        private void OnDestroy()
        {
            exitButton.onClick.RemoveAllListeners();
            tapToStartButton.onClick.RemoveAllListeners();
        }
        #endregion
        public void Display(Action callback = null)
        {
            viewModel.SetLeaderboard();
            leaderboardPanel.SetActive(true);
            AnimateDisplay();
        }

        public void Hide(Action callback = null)
        {
            AnimateHide();
        }

        public void SetLayoutSize(float entryTransformSizeDeltaY, int entryCount)
        {
            layoutPanel.sizeDelta = new Vector2(layoutPanel.sizeDelta.x,
                layoutPanel.sizeDelta.y + (entryTransformSizeDeltaY * entryCount));
        }

        private void SetDefaultLayoutSize()
        {
            layoutPanel.sizeDelta = initialLayoutSize;
        }

        private void AnimateDisplay()
        {
            sequence = DOTween.Sequence();
            sequence.Append(layoutPanel.transform.DOScale(Vector3.zero, 0));
            sequence.Append(layoutPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(viewModel.UIConfig.LeaderboardOpeningCurve));
        }

        private void AnimateHide()
        {
            sequence = DOTween.Sequence();
            sequence.Append(layoutPanel.transform.DOScale(Vector3.zero, 0));
            sequence.Append(layoutPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(viewModel.UIConfig.LeaderboardClosingCurve)).OnComplete(() =>
            {
                leaderboardPanel.SetActive(false);
                viewModel.Clear();
                SetDefaultLayoutSize();
            });
        }
    }
}
