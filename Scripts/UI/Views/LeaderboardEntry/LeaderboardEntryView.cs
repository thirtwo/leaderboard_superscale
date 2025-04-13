// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using DG.Tweening;
using System;
using System.Collections;
using Thirtwo.MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Thirtwo.UI
{
    public class LeaderboardEntryView : View<LeaderboardEntryVM>, ILeaderboardEntryView, IDisposable
    {
        [SerializeField] private Image rankImage;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image userColor;
        [SerializeField] private Image avatar;
        [SerializeField] private Image flag;
        [SerializeField] private Image vipStatus;
        [SerializeField] private TextMeshProUGUI placeText;
        [SerializeField] private TextMeshProUGUI nickName;
        [SerializeField] private TextMeshProUGUI points;
        [SerializeField] private RectTransform entry;

        private Sequence sequence;

        public void Construct(LeaderboardEntryVM leaderboardEntryVM)
        {
            viewModel = leaderboardEntryVM;
        }
        public float GetEntrySizeY()
        {
            return entry.sizeDelta.y;
        }
        public void HighlightBackground()
        {
            backgroundImage.sprite = viewModel.Model.HighlightBackground;
        }
        public void SetEntryView(LeaderboardEntryViewData data)
        {
            rankImage.sprite = data.RankImage;
            userColor.color = data.UserColor;
            avatar.sprite = data.Avatar;
            flag.sprite = data.Flag;
            vipStatus.sprite = data.VipStatus;
            placeText.text = data.Rank.ToString();
            nickName.text = data.NickName;
            points.text = data.Points.ToString();
            transform.localScale = Vector3.one;
            rankImage.enabled = data.RankImage != null;
            vipStatus.enabled = data.VipStatus != null;


            AnimateEntrance();
        }
        private void AnimateEntrance()
        {
            sequence = DOTween.Sequence();
            sequence.AppendInterval(0.3f);

            sequence.Append(transform.DOPunchScale(new Vector3(1f, 1f, 1f), 0.5f).SetEase(viewModel.UIConfig.EntryPointSlideCurve));
        }
        public void Display(Action callback = null)
        {
            gameObject.SetActive(true);
        }

        public void Hide(Action callback = null)
        {
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            Destroy(gameObject); // need object pooling 
        }
    }

    public class LeaderboardEntryViewData
    {
        public Sprite RankImage;
        public Color UserColor;
        public Sprite Avatar;
        public Sprite Flag;
        public Sprite VipStatus;
        public string NickName;
        public int Rank;
        public int Points;
    }
}
