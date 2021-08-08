using OperacionFuegoDeQuasar.Model;
using OperacionFuegoDeQuasar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperacionFuegoDeQuasar.Service
{
    public class SateliteService : ISateliteService
    {
        private readonly IValidacionService _validacionService;
        private List<SateliteModel> _satelites;
        private List<SateliteModel> _satelitesConocidos;
        public SateliteService(IValidacionService validacionService)
        {
            _validacionService = validacionService;
            _satelites = new List<SateliteModel>();
            _satelitesConocidos = new List<SateliteModel>();
            _satelitesConocidos.Add(new SateliteModel() { Nombre = "Kenobi", Posicion = new PosicionModel() { X = -500, Y = -200 } });
            _satelitesConocidos.Add(new SateliteModel() { Nombre = "Skywalker", Posicion = new PosicionModel() { X = 100, Y = -100 } });
            _satelitesConocidos.Add(new SateliteModel() { Nombre = "Sato", Posicion = new PosicionModel() { X = 500, Y = 100 } });
        }
        public IEnumerable<SateliteModel> GetSatelitesConocidos()
        {
            try
            {
                return _satelitesConocidos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<SateliteModel> GetSatelites()
        {
            try
            {
                return _satelites;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string GuardarSatelite(SateliteModel satelite, string sateliteName)
        {
            try
            {
                satelite.Nombre = sateliteName;

                if (_satelites.Count == 3) 
                    throw new Exception("Los satelites ya estan cargados.");

                if(_satelites.Exists(x => x.Nombre.ToLower() == satelite.Nombre.ToLower()))
                    throw new Exception(" El satelite introducido ya fue cargado.");

                _validacionService.ValidaSatelite(satelite, _satelitesConocidos);

                SateliteModel satConocido = _satelitesConocidos.ToList().Find(x => x.Nombre.ToLower() == satelite.Nombre.ToLower());
                satelite.Posicion = new PosicionModel() { X = satConocido.Posicion.X, Y = satConocido.Posicion.Y };

                _satelites.Add(satelite);

                return "Satelite guardado con éxito";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LimpiarSatelitesCargados()
        {
            try
            {
                _satelites.Clear();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
