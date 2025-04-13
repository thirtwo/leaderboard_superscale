// All rights reserved 2024 ©
// Copyright (c) Ekrem Bugra Berdan thirtwo@protonmail.com

namespace Thirtwo.MVVM
{
    public abstract class ViewModel<TView, TModel> : IViewModel
    {
        public TView View { get; protected set; }
        public TModel Model { get; protected set; }


        public virtual void OnDisplay()
        {
        }

        public virtual void OnHide()
        {
        }
    }
}
