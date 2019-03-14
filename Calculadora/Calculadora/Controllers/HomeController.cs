using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//---A VIEWBAG É O QUE LEVA OS VALORES DO CONTROLADOR PARA A VIEW---

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //inicializa o visor com o valor '0'
            ViewBag.Ecra = "0";

            Session["primeiraVezOperador"] = true;
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor){
            // var aux
            string ecra = visor;

            //identificar o valor na variável 'bt'
            switch (bt)
            {
                //se entrar aqui é porque foi selecionado um 'algarismo'
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":

                    //vou decidir o que fazer quando no visor só existe o '0'
                    if (visor == "0")  //if(visor.equals("0"))
                    {
                        ecra = bt;
                    }
                    else
                    {
                        ecra = ecra + bt;
                    }
                break;

                case ",":
                    //processar o caso da ','
                    if (!visor.Contains(",")) ecra = ecra + bt; 
                    break;

                case "C":
                    ecra = "0";
                    break;

                //se entrar aqui é porque foi selecionado um 'operador'
                case "+":
                case "-":
                case "x":
                case ":":
                    //é a primeira vez que carreguei num destes operadores?
                    if((bool)Session["primeiraVezOperador"] == true)
                    {

                    }
                    break;
            }

            //prepara o conteudo a aparecer no VISOR da View
            ViewBag.Ecra = ecra;

            return View();
        }



    }
}