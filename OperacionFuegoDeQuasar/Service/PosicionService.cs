using OperacionFuegoDeQuasar.Model;
using OperacionFuegoDeQuasar.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperacionFuegoDeQuasar.Service
{
    public class PosicionService : IPosicionService
    {
        private readonly IValidacionService _validaciones;
        private readonly ISateliteService _sateliteService;
        public PosicionService(IValidacionService validacion, ISateliteService sateliteService)
        {
            _validaciones = validacion;
            _sateliteService = sateliteService;
        }
        public PosicionModel GetLocation(IEnumerable<SateliteModel> satelites)
        {
            try
            {   
                _validaciones.ValidaSatelites(satelites, _sateliteService.GetSatelitesConocidos());

                return CalcularPosicion(satelites);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private PosicionModel CalcularPosicion(IEnumerable<SateliteModel> satelites)
        {
            try
            {
                //Se resuelve con la ecuacion de Trilateracion
                PosicionModel pUno = new PosicionModel() { X = satelites.ToList()[0].Posicion.X, Y = satelites.ToList()[0].Posicion.Y };
                PosicionModel pDos = new PosicionModel() { X = satelites.ToList()[1].Posicion.X, Y = satelites.ToList()[1].Posicion.Y };
                PosicionModel pTres = new PosicionModel() { X = satelites.ToList()[2].Posicion.X, Y = satelites.ToList()[2].Posicion.Y };

                float dUno = (float)satelites.ToList()[0].Distancia;
                float dDos = (float)satelites.ToList()[1].Distancia;
                float dTres = (float)satelites.ToList()[2].Distancia;

                float iUno = pUno.X;
                float iDos = pDos.X;
                float iTres = pTres.X;

                float jUno = pUno.Y;
                float jDos = pDos.Y;
                float jTres = pTres.Y;

                float x = (float)(
                                    (((Math.Pow(dUno, 2) - Math.Pow(dDos, 2)) + (Math.Pow(iDos, 2) - Math.Pow(iUno, 2)) +
                                    (Math.Pow(jDos, 2) - Math.Pow(jUno, 2))) * ((2 * jTres) - (2 * jDos)) -
                                    ((Math.Pow(dDos, 2) - Math.Pow(dTres, 2)) + (Math.Pow(iTres, 2) - Math.Pow(iDos, 2)) +
                                    (Math.Pow(jTres, 2) - Math.Pow(jDos, 2))) * ((2 * jDos) - (2 * jUno))) /
                                    (((2 * iDos) - (2 * iTres)) * ((2 * jDos) - (2 * jUno)) -
                                    ((2 * iUno) - (2 * iDos)) * ((2 * jTres) - (2 * jDos)))
                                  );

                float y = (float)( 
                                    ((Math.Pow(dUno, 2) - Math.Pow(dDos, 2)) +
                                    (Math.Pow(iDos, 2) - Math.Pow(iUno, 2)) +
                                    (Math.Pow(jDos, 2) - Math.Pow(jUno, 2)) +
                                    (x * ((2 * iUno) - (2 * iDos))) ) / ((2 * jDos) - (2 * jUno))
                                );
                                 
                return new PosicionModel() { X = x, Y = y };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
