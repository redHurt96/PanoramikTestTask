using System;
using UnityEngine;

namespace TestTask.Presentation.UI.RankingsWindow
{
    internal struct RankingsWindowCommonModel
    {
        internal Action OnPreviousButtonClick;
        internal Action OnNextButtonClick;
        internal Action OnBackButtonClick;
        internal Sprite Background;
        internal int ItemsPerPage;
    }
}