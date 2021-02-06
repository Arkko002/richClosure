﻿using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reactive.Disposables;
using ReactiveUI;

namespace richClosure.Avalonia.ViewModels
{
    public class InterfaceSelectionViewModel : ViewModelBase, IActivatableViewModel 
    {
        public List<NetworkInterface> NetworkInterfaces { get; set; }

        private NetworkInterface _selectedInterface;

        public NetworkInterface SelectedInterface
        {
            get => _selectedInterface;
            set => this.RaiseAndSetIfChanged(ref _selectedInterface, value);
        }

        public ViewModelActivator Activator { get; }
        
        public InterfaceSelectionViewModel()
        {
            Activator = new ViewModelActivator();
            this.WhenActivated((disposable) =>
            {
                Disposable
                    .Create(() => {})
                    .DisposeWith(disposable);
            });
            
            NetworkInterfaces = new List<NetworkInterface>();

            PopulateInterfaceList();
        }

        private void PopulateInterfaceList()
        {
            NetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces().ToList();
        }

        private void ChoseInterface()
        {
            //TODO
            CloseSelectionWindow();
        }

        private void CloseSelectionWindow()
        {
            // TODO 
        }
    }
}
