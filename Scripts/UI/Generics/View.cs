// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using UnityEngine;
namespace Thirtwo.MVVM
{
    public abstract class View<TViewModel> : MonoBehaviour
    where TViewModel : IViewModel 
    {
        protected TViewModel viewModel;

    }
}
