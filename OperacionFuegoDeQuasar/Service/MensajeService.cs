using OperacionFuegoDeQuasar.Model;
using OperacionFuegoDeQuasar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperacionFuegoDeQuasar.Service
{
    public class MensajeService : IMensajeService
    {
        private readonly IValidacionService _validacionService;
        private readonly ISateliteService _sateliteService;
        public MensajeService(IValidacionService validacionService, ISateliteService sateliteService)
        {
            _validacionService = validacionService;
            _sateliteService = sateliteService;
        }
        public string GetMessage(IEnumerable<SateliteModel> satelites)
        {
            try
            {
                _validacionService.ValidaSatelites(satelites, _sateliteService.GetSatelitesConocidos());

                string mensaje = "";
                for (int i = 0; i < satelites.First().Mensaje.Length; i++)
                {
                    bool encontroMsj = false;
                    foreach (SateliteModel sate in satelites)
                    {
                        if (sate.Mensaje[i].Length > 0)
                        {
                            mensaje += $"{sate.Mensaje[i]} ";
                            encontroMsj = true;
                            break;
                        }
                    }
                    if (!encontroMsj)
                        throw new Exception("No se puede descifrar el mensaje.");
                }
                return mensaje;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
