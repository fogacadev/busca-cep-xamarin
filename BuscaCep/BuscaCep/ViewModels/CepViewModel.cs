using BuscaCep.Models;
using BuscaCep.Repositories;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BuscaCep.ViewModels
{
    public class CepViewModel : INotifyPropertyChanged
    {
        private Cep cep;

        public Cep Cep
        {
            get { return cep; }
            set { cep = value; OnPropertyChanged(string.Empty); }
        }

        private string cepBusca;
        public string CepBusca
        {
            get { return cepBusca; }
            set { cepBusca = value; OnPropertyChanged(); }
        }

        private Command buscarCommand;

        public Command BuscarCommand
        {
            get { return buscarCommand; }
            set { buscarCommand = value; }
        }

        private readonly CepRepository _cepRepository;


        public CepViewModel()
        {
            _cepRepository = new CepRepository();
            BuscarCommand = new Command(Buscar, PodeBuscar);
        }

        private async void Buscar()
        {
            try
            {
                if (string.IsNullOrEmpty(CepBusca)) return;

                var cepResponse = await _cepRepository.Get(CepBusca);

                this.Cep = cepResponse;

            }
            catch(Exception ex)
            {
                if(ex.InnerException is ApiException)
                {
                    var apiEx = ex as ApiException;
                    MessagingCenter.Send<string>(apiEx.Content, "ShowDisplay");
                }
                else
                {
                    MessagingCenter.Send<string>(ex.Message, "ShowDisplay");
                }
                
                
            }
        }

        private bool PodeBuscar()
        {
            return !string.IsNullOrEmpty(CepBusca);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            BuscarCommand?.ChangeCanExecute();
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
