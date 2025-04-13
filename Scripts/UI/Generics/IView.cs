// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

using System;

namespace Thirtwo.MVVM
{
    public interface IView
    {
        void Display(Action callback = null);
        void Hide(Action callback = null);
    }
}
