namespace nuevo.Controllers
{
    using iText.Kernel.Pdf;
    using iText.Forms;
    using iText.Forms.Fields;
    using iText.Layout;
    using iText.Layout.Element;
    using System.IO;
    using Microsoft.AspNetCore.Mvc;

    public class PdfController : Controller
    {
        public IActionResult GenerarPDF()
        {
            // Ruta de la plantilla PDF
            string plantillaPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HojasDeServicio/cfematico.pdf");
            string salidaPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HojasDeServicio/", "cfemativo_new.pdf");

            using (PdfReader reader = new PdfReader(plantillaPath))
            using (PdfWriter writer = new PdfWriter(salidaPath))
            using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
            {
                // Acceder al formulario dentro del PDF
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);

                // Rellenar campos con datos estáticos
                form.GetField("campo1").SetValue("Valor del campo 1");
                form.GetField("campo2").SetValue("Valor del campo 2");
                form.GetField("campo3").SetValue("Valor del campo 3");

                // Asegurarse de que los cambios se guarden
                form.FlattenFields(); // Hace que los campos ya no sean editables

                // Guardar el PDF con los datos
                pdfDoc.Close();
            }

            // Devolver el PDF generado a la vista
            return File(salidaPath, "application/pdf");
        }
    }

}
