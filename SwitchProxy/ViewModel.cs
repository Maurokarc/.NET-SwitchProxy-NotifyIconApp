using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SwitchProxy
{
    internal class ViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void Notify([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region private Members
        private readonly Action<string> _ShowTip;
        private bool _IsProxyOpened;
        private string _SwitcherText;

        #endregion

        #region Properties

        public bool IsProxyOpened
        {
            get => _IsProxyOpened;
            private set
            {
                _IsProxyOpened = value;
                Notify();
            }
        }

        public string SwitcherText
        {
            get => _SwitcherText;
            private set
            {
                _SwitcherText = value;
                Notify();
            }
        }

        private string StatusText => !IsProxyOpened ? "Open" : "Close";

        #endregion

        public ViewModel(Action<string> ShowTip)
        {
            _ShowTip = ShowTip;
            IsProxyOpened = ProxyHelper.IsProxyOpened();
            _ShowTip("Switch Proxy is On");
            SwitcherText = $"Switch Proxy ( to {StatusText})";
        }

        public void SetProxy(bool open)
        {
            var result = ProxyHelper.SetProxy(open);
            IsProxyOpened = ProxyHelper.IsProxyOpened();
            _ShowTip($"Proxy is {(IsProxyOpened ? "Open" : "Close")} now");
            SwitcherText = $"Switch Proxy ( to {StatusText})";
        }
    }
}
