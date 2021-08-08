using OperacionFuegoDeQuasar.Model;
using OperacionFuegoDeQuasar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperacionFuegoDeQuasar.Service
{
    public class ValidacionService : IValidacionService
    {
        public void ValidaSatelite(SateliteModel satelite, IEnumerable<SateliteModel> satelitesConocidos)
        {
            try
            {
                ValidaInfo(satelite, satelitesConocidos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ValidaSatelites(IEnumerable<SateliteModel> satelites, IEnumerable<SateliteModel> satelitesConocidos)
        {
            try
            {
                if (satelites.Count() < 3)
                    throw new Exception("No hay suficiente iformacion para determinar la posición.");

                foreach (SateliteModel satelite in satelites.ToList())
                {
                    ValidaInfo(satelite, satelitesConocidos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ValidaInfo(SateliteModel satelite, IEnumerable<SateliteModel> satelitesConocidos)
        {
            try
            {
                SateliteModel satConocido = satelitesConocidos.ToList().Find(x => x.Nombre.ToLower() == satelite.Nombre.ToLower());

                if (satConocido == null)
                    throw new Exception("No se puede cargar un satelite desconocido.");

                satelite.Posicion = new PosicionModel() { X = satConocido.Posicion.X, Y = satConocido.Posicion.Y };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
