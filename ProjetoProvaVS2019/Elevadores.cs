using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaAdmissionalCSharpApisul
{
    public class Elevadores : IElevadorService
    {
        bool debug = true;
        public List<int> andarMenosUtilizado()
        {
            var ret = new List<int>();

            var dados = GetDados.Load();

            int item = -1;

            
            

            foreach (var line in dados.GroupBy(i => i.andar)
                        .Select(group => new {
                            Andar = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Count))
            {

                item = item == -1 ? line.Count : item;
                if(line.Count == item)
                {
                    item = line.Count;
                    ret.Add(line.Andar);
                   
                    Console.WriteLine("Andar(es) menos visitado: {0} {1}", line.Andar, line.Count);
                }
                else
                {
                    break;
                }
                    
            }


            return ret;
        }


        public List<char> elevadorMaisFrequentado()
        {
            var ret = new List<char>();

            var dados = GetDados.Load();

            int item = -1;

            foreach (var line in dados.GroupBy(i => i.elevador)
                        .Select(group => new {

                            Elevador = group.Key,
                            Count = group.Count()
                        })
                        .OrderByDescending(x => x.Count))
            { 

                item = item == -1 ? line.Count : item;
                if (line.Count == item)
                {
                    item = line.Count;
                    ret.Add(line.Elevador);
                    if(debug)
                    Console.WriteLine("Elevador(es) mais visitado: {0} {1}", line.Elevador, line.Count);
                }
                else
                {
                    break;
                }

            }


            return ret;
        }



        public List<char> elevadorMenosFrequentado()
        {
            var ret = new List<char>();

            var dados = GetDados.Load();

            int item = -1;

            foreach (var line in dados.GroupBy(i => i.elevador)
                        .Select(group => new {

                            Elevador = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Count))
            {

                item = item == -1 ? line.Count : item;
                if (line.Count == item)
                {
                    item = line.Count;
                    ret.Add(line.Elevador);
                    if(debug)
                    Console.WriteLine("Elevador(es) menos visitado: {0} {1}", line.Elevador, line.Count);
                }
                else
                {
                    break;
                }

            }


            return ret;
        }


        public float percentualDeUsoElevadorA()
        {

            return UsoElevador('A');
        }

        public float percentualDeUsoElevadorB()
        {
            return UsoElevador('B');
        }

        public float percentualDeUsoElevadorC()
        {
            return UsoElevador('C');
        }

        public float percentualDeUsoElevadorD()
        {
            return UsoElevador('D');
        }

        public float percentualDeUsoElevadorE()
        {
            return UsoElevador('E');
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var ret = new List<char>();

            var dados = GetDados.Load();

            int item = -1;
            debug = false;

            var dadosEl = dados
                        .Where(x => elevadorMaisFrequentado().Contains(x.elevador)).ToList();

            foreach (var line in dadosEl
                        .GroupBy(i => new { i.elevador, i.turno } )
                        .Select(group => new {
                            Turno = group.Key.turno,
                            Elevador = group.Key.elevador,
                            Count = group.Count()})
                        .OrderByDescending(x => x.Count))
            {

                item = item == -1 ? line.Count : item;
                if (line.Count == item)
                {
                    item = line.Count;
                    ret.Add(line.Turno);
                    Console.WriteLine("Fluxo de turno  mais visitado  '{0}' dos elevador {1} mais frequentado  ", line.Turno, line.Elevador);
                }
                else
                {
                    break;
                }

            }


            return ret;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var ret = new List<char>();

            var dados = GetDados.Load();

            int item = -1;

            foreach (var line in dados
                        .GroupBy(i => i.turno)
                        .Select(group => new {
                            Turno = group.Key,
                            Count = group.Count()})
                        .OrderByDescending(x => x.Count))
            {

                item = item == -1 ? line.Count : item;
                if (line.Count == item)
                {
                    item = line.Count;
                    ret.Add(line.Turno);
                    Console.WriteLine("Turnos mais visitado: {0} {1}", line.Turno, line.Count);
                }
                else
                {
                    break;
                }

            }


            return ret;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var ret = new List<char>();
            debug = false;
            var dados = GetDados.Load();

            int item = -1;
            var dadosF = dados
                        .Where(x => elevadorMenosFrequentado()
                        .Contains(x.elevador));

            foreach (var line in dadosF
                        .GroupBy(i => new { i.elevador, i.turno })
                        .Select(group => new {
                            Turno = group.Key.turno,
                            Elevador = group.Key.elevador,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Count))
            {

                item = item == -1 ? line.Count : item;
                if (line.Count == item)
                {
                    item = line.Count;
                    ret.Add(line.Turno);
                    Console.WriteLine("Fluxo de turno menos visitado  '{0}' do elevador {1} mais frequentado  ", line.Turno, line.Elevador);
                }
                else
                {
                    break;
                }

            }


            return ret;
        }


        private float UsoElevador(char Elevador)
        {
            float ret = 0;

            var dados = GetDados.Load();

            foreach (var line in dados.GroupBy(i => i.elevador)
                        .Where(x => x.Key == Elevador)
                        .Select(group => new {

                            Elevador = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Count))
            {


                ret = (float)dados.Count / line.Count;
                Console.WriteLine("Uso elevador '{0}' : {1} %", Elevador,(float) dados.Count / line.Count);


            }


            return ret;
        }
    }
}
