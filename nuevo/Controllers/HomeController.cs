using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nuevo.Models;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

using nuevo.Models.ViewModels;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;


namespace nuevo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CfepruebadosContext _dbocontext;

        public HomeController(CfepruebadosContext context)
        {
            _dbocontext = context;
        }

        // Acci�n por defecto que muestra la vista Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        // Nueva acci�n que muestra la vista Inicio.cshtml (Dashboard)
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Agendar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();

            IWorkbook MiExcel = null;

            // Mantenemos el if/else como pediste
            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;

            List<VMMantenimiento> lista = new List<VMMantenimiento>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                string fechaFormateada = "";

                // Validación segura para fecha
                if (fila.GetCell(5) != null && fila.GetCell(5).CellType == CellType.Numeric)
                {
                    DateTime? fecha = fila.GetCell(5).DateCellValue;
                    fechaFormateada = fecha.HasValue ? fecha.Value.ToString("yyyy-MM-dd") : "";
                }

                lista.Add(new VMMantenimiento
                {
                    numactfijo = fila.GetCell(0).ToString(),
                    clavedivision = fila.GetCell(1).ToString(),
                    clavezona = fila.GetCell(2).ToString(),
                    claveagencia = fila.GetCell(3).ToString(),
                    clavetipomtto = fila.GetCell(4).ToString(),
                    fechaprogramada = fechaFormateada
                });
            }

            return StatusCode(StatusCodes.Status200OK, lista);

        }


        [HttpPost]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();

            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;

            List<Mantenimiento> lista = new List<Mantenimiento>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                // ✅ Leer fecha segura
                DateTime fechaProgramada = DateTime.MinValue;

                if (fila.GetCell(5) != null && fila.GetCell(5).CellType == CellType.Numeric)
                {
                    DateTime? fecha = fila.GetCell(5).DateCellValue;
                    fechaProgramada = fecha.HasValue ? fecha.Value : DateTime.MinValue;
                }

                // ✅ Ahora sí se asigna también FechaProgramada
                lista.Add(new Mantenimiento
                {
                    NumActFijo = (int)fila.GetCell(0).NumericCellValue,
                    ClaveDivision = fila.GetCell(1).ToString(),
                    ClaveZona = fila.GetCell(2).ToString(),
                    ClaveAgencia = fila.GetCell(3).ToString(),
                    ClaveTipoMtto = fila.GetCell(4).ToString(),
                    FechaProgramada = fechaProgramada
                });
            }

            _dbocontext.BulkInsert(lista);

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Sus datos se han enviado corrcetamente" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MCCFEmatico()
        {
            return PartialView("MCCFEmatico");
        }

        public IActionResult MCCFEturno()
        {
            return PartialView("MCCFEturno");
        }

        public IActionResult MCCFEcam()
        {
            return PartialView("MCCFEcam");
        }

        public IActionResult MCPC()
        {
            return PartialView("MCPC");
        }

        public IActionResult MCLaptop()
        {
            return PartialView("MCLaptop");
        }

        public IActionResult Monitoreo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


