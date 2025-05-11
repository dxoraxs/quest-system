using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem.UI.Views
{
    public class TaskUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _progressBar;
        [SerializeField] private CanvasGroup _checkMark;

        public void SetDescription(string text) => _description.text = text;
        public void SetProgress(float value) => _progressBar.fillAmount = value;
        public void SetCompleted(bool isCompleted) => _checkMark.alpha = isCompleted ? 1 : 0;
    }
}